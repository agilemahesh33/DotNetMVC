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
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
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
        public int InsertStudent(Student student)
        {
            int count = 0;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Student_Insert";
                cmd.Parameters.AddWithValue("@Sid", student.SId);
                cmd.Parameters.AddWithValue("@Name", student.SName);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@Fees", student.Fees);
                if (student.Photo != null && student.Photo.Length != 0)
                {
                    cmd.Parameters.AddWithValue("@Photo", student.Photo);
                }
                con.Open();
                count = cmd.ExecuteNonQuery();
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
            return count;
        }
        public int UpdateStudent(Student student)
        {
            int count = 0;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Student_Update";
                cmd.Parameters.AddWithValue("@Sid", student.SId);
                cmd.Parameters.AddWithValue("@Name", student.SName);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@Fees", student.Fees);
                if (student.Photo != null && student.Photo.Length != 0)
                {
                    cmd.Parameters.AddWithValue("@Photo", student.Photo);
                }
                con.Open();
                count = cmd.ExecuteNonQuery();
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
            return count;
        }
        public int DeleteStudent(int Sid)
        {
            int count = 0;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Student_Delete";
                cmd.Parameters.AddWithValue("@SId", Sid);
                con.Open();
                count = cmd.ExecuteNonQuery();
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
            return count;
        }
    }
}