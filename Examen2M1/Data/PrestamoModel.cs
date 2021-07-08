using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Examen2M1.Interfaces;
using Examen2M1.Poco;

namespace Examen2M1.Data
{
    public class PrestamoModel : IPrestamo
    {
        private const int SIZE = 91;
        private RAFContext raf;

        public PrestamoModel(string fileName)
        {
            raf = new RAFContext(fileName, SIZE);
        }

        public void Create(Prestamo t)
        {
            raf.Create(t);
        }

        public bool Delete(Prestamo t)
        {
            return raf.Delete(t);
        }

        public IEnumerable<Prestamo> Find(Expression<Func<Prestamo, bool>> where)
        {
            return raf.Find(where);
        }

        public IEnumerable<Prestamo> GetAll()
        {
            return raf.GetAll<Prestamo>();
        }

        public bool Update(Prestamo t)
        {
            return raf.Update(t);
        }
    }
}
