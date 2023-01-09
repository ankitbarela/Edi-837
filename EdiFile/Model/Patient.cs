using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdiFile.Model
{
  public  class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Insurance { get; set; }
        public string InsuranceType { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
    }
}
