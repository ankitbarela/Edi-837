using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdiFile
{
    class Edi850
    {
        public void EdiFile()
        {
            Console.WriteLine("*************************Edi 850 File*********************");
            StringBuilder edi = new StringBuilder();
            edi.Append("ISA*00*      ");
            edi.Append("*00*      ");
            edi.Append("*ZZ*Ankit123      ");
            edi.Append("*ZZ*Amit123");
            edi.AppendLine();
            edi.Append("*200901*0201*U*00401*000012911*0T>~");
            edi.AppendLine();
            edi.Append("GS*HC*CUSTOMERID*SUPPLIERID*20020901*0201*12911*X*004010~");
            edi.AppendLine();
            edi.Append("ST*837*0001~");
            edi.AppendLine();
            edi.Append("SE*10*0001~");
            edi.AppendLine();
            edi.Append("GE*1*12911~");
            edi.AppendLine();
            edi.Append("IEA*1*000012911~");
            edi.AppendLine();
            Console.WriteLine(edi);
        }
    }
}
