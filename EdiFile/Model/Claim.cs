using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdiFile.Model
{
   public class Claim
    {
        public int ClaimId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public double Amount { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
