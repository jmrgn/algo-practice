using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class FileWriter
    {
        public static void WriteLines<T>(T[] toWrite, string path)
        {
            var converted = toWrite.Select(t => t.ToString());
            if (File.Exists(path))
            {
                throw new ArgumentException(string.Format("The file path: '{0}' already exists", path));
            }
            File.WriteAllLines(path, converted, Encoding.UTF8);
        }
    }
}
