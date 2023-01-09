using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdiFile.Model
{
  public  class ServiceLine
    {
        public int ServiceId { get; set; }
        public int ClaimId { get; set; }
        public string Procedure { get; set; }
        public float Charge { get; set; }
        public string ServiceDate { get; set; }
    }
}
