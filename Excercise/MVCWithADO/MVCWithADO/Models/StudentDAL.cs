using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace MVCWithADO.Models
{
    public class StudentDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        public StudentDAL()
        {
            string ConStr = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            con = new SqlConnection(ConStr);
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
        }
        public List<Student> SelectStudents(int? Sid, bool? Status)
        {
            List<Student> students = new List<Student>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Student_Select";
                if (Sid != null && Status != null)
                {
                    cmd.Parameters.AddWithValue("@Sid", Sid);
                    cmd.Parameters.AddWithValue("@Status", Status);
                }
                else if (Sid != null && Status == null)
                {
                    cmd.Parameters.AddWithValue("@Sid", Sid);
                }
                else if (Sid == null && Status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", Status);
                }
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Student student = new Student()
                    {
                        SId = Convert.ToInt32(dr["Sid"]),
                        SName = Convert.ToString(dr["Name"]),
                        Class = Convert.ToInt32(dr["Class"]),
                        Fees = Convert.ToDecimal(dr["Fees"]),
                        Photo = Convert.ToString(dr["Photo"])
                    };
                    students.Add(student);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return students;
        }
    }
}