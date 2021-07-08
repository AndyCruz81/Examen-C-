using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Examen2M1.Data
{
    public class RAFContext
    {
        private string fileName;
        private readonly int size;

        public RAFContext(string fileName, int size)
        {
            this.fileName = fileName;
            this.size = size;
        }

        public Stream HeaderStream
        {
            get => File.Open($"{fileName}.hd", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public Stream DataStream
        {
            get => File.Open($"{fileName}.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public void Create<T>(T t)
        {
            using (BinaryWriter bwHeader = new BinaryWriter(HeaderStream),
                                  bwData = new BinaryWriter(DataStream))
            {
                int n, k;
                using (BinaryReader brHeader = new BinaryReader(bwHeader.BaseStream))
                {
                    if (brHeader.BaseStream.Length == 0)
                    {
                        n = 0;
                        k = 0;
                    }
                    else
                    {
                        brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                        n = brHeader.ReadInt32();
                        k = brHeader.ReadInt32();
                    }
                    //calculamos la posicion en Data
                    long pos = k * size;
                    bwData.BaseStream.Seek(pos, SeekOrigin.Begin);

                    PropertyInfo[] info = t.GetType().GetProperties();

                    Write(bwData, info, ++k, t);

                    long posh = 8 + n * 4;
                    bwHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                    bwHeader.Write(k);

                    bwHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                    bwHeader.Write(++n);
                    bwHeader.Write(k);
                }
            }
        }

        public T Get<T>(int id)
        {
            T newValue = (T)Activator.CreateInstance(typeof(T));
            using (BinaryReader brHeader = new BinaryReader(HeaderStream),
                                brData = new BinaryReader(DataStream))
            {
                brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                int n = brHeader.ReadInt32();
                int k = brHeader.ReadInt32();

                if (id <= 0 || id > k)
                {
                    return default;
                }

                PropertyInfo[] properties = newValue.GetType().GetProperties();
                long posh = 8 + (id - 1) * 4;
                brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                int index = brHeader.ReadInt32();

                long posd = (index - 1) * size;
                brData.BaseStream.Seek(posd, SeekOrigin.Begin);
                foreach (PropertyInfo pinfo in properties)
                {
                    Type type = pinfo.PropertyType;

                    if (type.IsGenericType)
                    {
                        continue;
                    }

                    if (type == typeof(int))
                    {
                        pinfo.SetValue(newValue, brData.ReadInt32());
                    }
                    else if (type == typeof(long))
                    {
                        pinfo.SetValue(newValue, brData.ReadInt64());
                    }
                    else if (type == typeof(float))
                    {
                        pinfo.SetValue(newValue, brData.ReadSingle());
                    }
                    else if (type == typeof(double))
                    {
                        pinfo.SetValue(newValue, brData.ReadDouble());
                    }
                    else if (type == typeof(decimal))
                    {
                        pinfo.SetValue(newValue, brData.ReadDecimal());
                    }
                    else if (type == typeof(char))
                    {
                        pinfo.SetValue(newValue, brData.ReadChar());
                    }
                    else if (type == typeof(bool))
                    {
                        pinfo.SetValue(newValue, brData.ReadBoolean());
                    }
                    else if (type == typeof(string))
                    {
                        pinfo.SetValue(newValue, brData.ReadString());
                    }
                }

                return newValue;
            }
        }

        public List<T> GetAll<T>()
        {
            List<T> listT = new List<T>();
            int n, k;
            using (BinaryReader brHeader = new BinaryReader(HeaderStream))
            {
                brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                n = brHeader.ReadInt32();
                k = brHeader.ReadInt32();
            }

            for (int i = 0; i < n; i++)
            {
                int index;
                using (BinaryReader brHeader = new BinaryReader(HeaderStream))
                {
                    long posh = 8 + i * 4;
                    brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                    index = brHeader.ReadInt32();
                }

                T t = Get<T>(index);
                listT.Add(t);
            }

            return listT;
        }

        public bool Update<T>(T t)
        {
            using (BinaryReader brHeader = new BinaryReader(HeaderStream),
                                brData = new BinaryReader(DataStream))
            {
                brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                int n = brHeader.ReadInt32();

                //Verificamos que hayan elementos en el archivo
                if (n == 0)
                {
                    return false;
                }

                PropertyInfo[] properties = t.GetType().GetProperties();

                //Verificamos propiedad por propiedad hasta dar con el id
                int id = ObtenerId(properties, t);

                //Una vez obtenido el id, verificamos que exista en el header
                int pos = BinarySearch.Search(brHeader, id, 0, n - 1);

                //En caso de que retorne un valor negativo, significa que no existe ese id
                if (pos < 0)
                {
                    return false;
                }

                //Calculamos la posicion del objeto en el data a partir de su id
                long posd = (id - 1) * size;

                brData.BaseStream.Seek(posd, SeekOrigin.Begin); //Nos ubicamos en la posicion

                using (BinaryWriter bwData = new BinaryWriter(brData.BaseStream))
                {
                    Write(bwData, properties, id, t); //Mandamos a escribir todas su propiedades
                }
            }

            return true;
        }

        public bool Delete<T>(T t)
        {
            using (BinaryWriter bwHeader = new BinaryWriter(HeaderStream))
            {
                using (BinaryReader brHeader = new BinaryReader(bwHeader.BaseStream))
                {
                    //Creamos una lista para los ids que no serán eliminados
                    List<int> ids = new List<int>();

                    brHeader.BaseStream.Seek(0, SeekOrigin.Begin);

                    int n = brHeader.ReadInt32();
                    int k = brHeader.ReadInt32();

                    PropertyInfo[] properties = t.GetType().GetProperties();

                    int id = ObtenerId(properties, t); //Obtenemos el id del objeto t

                    for (int i = 0; i < n; i++)
                    {
                        long posh = 8 + i * 4;

                        brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);

                        int currentId = brHeader.ReadInt32();

                        //Siempre y cuando el id actual sea diferente del que se va a eliminar, se guarda en la lista
                        if (currentId != id)
                        {
                            ids.Add(currentId);
                        }
                    }

                    bwHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                    bwHeader.Write(--n); //Eliminamos un registro del header
                    bwHeader.Write(k);

                    /*
                     * Sobreescribimos los ids del header con los de nuestra lista,
                     * de este modo solo el id el objeto t que se desea eliminar no
                     * estará en el header y así su acceso al data nunca sucederá
                     */
                    foreach (int i in ids)
                    {
                        bwHeader.Write(i);
                    }
                }
            }

            return true;
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> where)
        {
            List<T> items = new List<T>();
            Func<T, bool> funcion = where.Compile();

            using (BinaryReader brHeader = new BinaryReader(HeaderStream),
                                brData = new BinaryReader(DataStream))
            {
                brHeader.BaseStream.Seek(0, SeekOrigin.Begin);

                int n = brHeader.ReadInt32();

                for (int i = 0; i < n; i++)
                {
                    long posh = 8 + i * 4;
                    brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                    int index = brHeader.ReadInt32();

                    T t = Get<T>(index);

                    if (funcion(t))
                    {
                        items.Add(t);
                    }
                }
            }

            return items;
        }

        private void Write<T>(BinaryWriter bw, PropertyInfo[] properties, int id, T t)
        {
            foreach (PropertyInfo pinfo in properties)
            {
                Type type = pinfo.PropertyType;
                object obj = pinfo.GetValue(t, null);

                if (type.IsGenericType)
                {
                    continue;
                }

                if (pinfo.Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase))
                {
                    bw.Write(id);
                    continue;
                }

                if (type == typeof(int))
                {
                    bw.Write((int)obj);
                }
                else if (type == typeof(long))
                {
                    bw.Write((long)obj);
                }
                else if (type == typeof(float))
                {
                    bw.Write((float)obj);
                }
                else if (type == typeof(double))
                {
                    bw.Write((double)obj);
                }
                else if (type == typeof(decimal))
                {
                    bw.Write((decimal)obj);
                }
                else if (type == typeof(char))
                {
                    bw.Write((char)obj);
                }
                else if (type == typeof(bool))
                {
                    bw.Write((bool)obj);
                }
                else if (type == typeof(string))
                {
                    bw.Write((string)obj);
                }
            }
        }

        private int ObtenerId<T>(PropertyInfo[] properties, T t)
        {
            foreach (PropertyInfo pInfo in properties)
            {
                Type type = pInfo.PropertyType;

                if (type.IsGenericType)
                {
                    continue;
                }

                if (pInfo.Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase))
                {
                    return (int)pInfo.GetValue(t, null);
                }
            }

            return 0;
        }
    }
}