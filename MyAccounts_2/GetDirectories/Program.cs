using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo
                = new DirectoryInfo(@"\\ivm-vandergrift\SupportData\FTPData\EmployeeLists2.0");

            var subdirs = directoryInfo.GetDirectories().ToList();

            using (StreamWriter sw = new StreamWriter("clients.txt"))
            {
                foreach (DirectoryInfo dir in subdirs)
                {
                    sw.Write(dir.Name + ",");
                }
            }


        }
    }
}
