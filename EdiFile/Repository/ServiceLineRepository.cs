using EdiFile.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdiFile.Repository
{
   public class ServiceLineRepository
    {
        SqlConnection conn;
        public ServiceLineRepository(SqlConnection conn)
        {
            this.conn = conn;
        }
        public List<ServiceLine> getServiceLines()
        {
            var serviceLines = new List<ServiceLine>();
            string query = "Select * from ServiceLines";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var service = new ServiceLine();
                    service.ClaimId = Convert.ToInt32(reader["ClaimId"]);
                    service.ServiceId = Convert.ToInt32(reader["ServiceId"]);
                    service.Charge = Convert.ToInt32(reader["Charge"]);
                    service.Procedure = reader["Procedure"].ToString();
                    service.ServiceDate = reader["ServiceDate"].ToString();
                    serviceLines.Add(service);
                }
                conn.Close();
            }
            return serviceLines;
        }
    }
}
