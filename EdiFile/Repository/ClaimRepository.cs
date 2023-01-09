using EdiFile.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdiFile.Repository
{
   public class ClaimRepository
    {
        SqlConnection conn;
        public ClaimRepository(SqlConnection conn)
        {
            this.conn = conn;
        }
        public List<Claim> getClaims()
        {
            var claims = new List<Claim>();
            string query = "Select * from Claims";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var claim = new Claim();
                    claim.PatientId = Convert.ToInt32(reader["PatientId"]);
                    claim.ClaimId = Convert.ToInt32(reader["ClaimId"]);
                    claim.Amount = Convert.ToDouble(reader["Amount"]);
                    claims.Add(claim);
                }
                conn.Close();
            }
            return claims;
        }
    }
}
