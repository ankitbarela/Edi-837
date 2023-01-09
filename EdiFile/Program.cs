using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdiFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************************Edi File*********************");
            var ediFile = new Edi837();
            ediFile.CreateEdiFile();
            Console.ReadLine();
        }
    }
}



