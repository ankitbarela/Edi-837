using EdiFile.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdiFile
{
   public class Edi837
    {
        SqlConnection conn;
        string connString;
        public Edi837()
        {
             connString = @"Server=XCDIFY_ANKIT\SQLEXPRESS;Database=ediDb;Trusted_Connection=True;";
             conn = new SqlConnection(connString);
        }
        public void CreateEdiFile()
        {
            var claim = new ClaimRepository(conn);
            var patient = new PatientRepository(conn);
            var serviceLine = new ServiceLineRepository(conn);
            var serviceLines = serviceLine.getServiceLines();
            var patients = patient.getPatients();
            var claims = claim.getClaims();
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
            edi.Append("NM1*41*2*Ankit*****46*TGJ23~");
            edi.AppendLine();
            edi.Append("PER*IC*Ani*TE*3055552222*EX*231~");
            edi.AppendLine();
            edi.Append("NM1*40*2*Amit*****46*66783JJT~");
            edi.AppendLine();
            foreach (var pat in patients)
            {
                edi.Append("HL*3*2*23*0~");
                edi.AppendLine();
                edi.Append("PAT*19~");
                edi.AppendLine();
                edi.Append($"NM1*QC*1*{pat.FirstName}*TED~");
                edi.AppendLine();
                edi.Append("N3*236 N MAIN ST~");
                edi.AppendLine();
                edi.Append("N4*MIAMI*FL*33413~");
                edi.AppendLine();
                edi.Append($"DMG*D8*{pat.Dob}*~{pat.Gender}");
            }
            edi.AppendLine();
            foreach (var clm in claims)
            {
                edi.Append($"CLM*{clm.ClaimId}*100***11:B:1*Y*A*Y*I~");
                edi.AppendLine();
                edi.Append("REF*D9*17312345600006351~");
            }
            edi.AppendLine();
            foreach (var service in serviceLines)
            {
                edi.Append("LX*1~ ");
                edi.AppendLine();
                edi.Append($"SV1*HC:99213*{service.Charge}*UN*1***1~");
                edi.AppendLine();
                edi.Append($"DTP*472*D8*{service.ServiceDate}~");
            }
            edi.AppendLine();
            edi.Append("SE*13*0001~");
            edi.AppendLine();
            edi.Append("GE*1*12911~");
            edi.AppendLine();
            edi.Append("IEA*1*000012911~");
            edi.AppendLine();
            Console.WriteLine(edi);
        }
    }
}
