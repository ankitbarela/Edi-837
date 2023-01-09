using EdiFile.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdiFile.Repository
{
   public class PatientRepository
    {
        SqlConnection conn;
        public PatientRepository(SqlConnection conn)
        {
            this.conn = conn;
        }
        public List<Patient> getPatients()
        {
            var patients = new List<Patient>();
            string query = "Select * from Patients";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var patient = new Patient();
                    patient.PatientId = Convert.ToInt32(reader["PatientId"]);
                    patient.FirstName = reader["FirstName"].ToString();
                    patient.LastName = reader["LastName"].ToString();
                    patient.Insurance = reader["Insurance"].ToString();
                    patient.InsuranceType = reader["InsuranceType"].ToString();
                    patient.Dob = reader["Dob"].ToString();
                    patient.Gender = reader["Gender"].ToString();
                    patients.Add(patient);
                }
                conn.Close();
            }
            return patients;
        }
    }
}
