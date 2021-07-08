using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2M1.Data
{
    public class BinarySearch
    {
        public static int Search(BinaryReader br, int key, int min, int max)
        {
            int index = int.MinValue;

            while (min <= max)
            {
                int mid = (min + max) / 2;

                long pos = 8 + (mid) * 4;

                br.BaseStream.Seek(pos, SeekOrigin.Begin);
                int id = br.ReadInt32();

                if (id < key)
                {
                    min = mid + 1;
                }
                else if (id > key)
                {
                    max = mid - 1;
                }
                else
                {
                    index = (int)pos;
                    break;
                }
            }

            return index;
        }
    }
}
