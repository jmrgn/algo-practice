using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class FileReader
    {
        public static List<T> ReadLines<T>(string fileName)
        {
            var lines = new List<T>();
            using (var file = new System.IO.StreamReader(fileName))
            {
                string line = null;
                while ((line = file.ReadLine()) != null)
                {
                    var converted = Convert.ChangeType(line, typeof(T));
                    lines.Add((T)converted);
                }
            }

            return lines;
        }
    }
}
