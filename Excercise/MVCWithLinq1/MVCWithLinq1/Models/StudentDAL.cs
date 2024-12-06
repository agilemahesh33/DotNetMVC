using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MVCWithLinq1.Models
{
    public class StudentDAL
    {
        MVCDBDataContext dc = new MVCDBDataContext(ConfigurationManager.ConnectionStrings["MVCDBConnectionString"].ConnectionString);
        public List<Student> GetStudents(bool? status)
        {
            List<Student> Students;// = new List<Student>();
            try
            {
                if (status == null)
                    Students = (from s in dc.Students select s).ToList();
                else
                    Students = (from s in dc.Students where s.Status == status select s).ToList();
                return Students;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Student GetStudent(int Sid, bool? Status)
        {            
            try
            {
                Student student = null;
                if (Status == null)                
                    student = (from s in dc.Students where s.Sid == Sid select s).Single();                
                else if (Status != null)                
                    student = (from s in dc.Students where s.Sid == Sid && s.Status == Status select s).Single();                
                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertStudent(Student model)
        {
            try
            {
                dc.Students.InsertOnSubmit(model);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateStudent(Student NewStudmodel)
        {
            try
            {
                Student oldStud = dc.Students.First(S => S.Sid == NewStudmodel.Sid);                
                oldStud.Name = NewStudmodel.Name;
                oldStud.Class = NewStudmodel.Class; 
                oldStud.Fees = NewStudmodel.Fees;
                oldStud.Photo = NewStudmodel.Photo;
                oldStud.Status = NewStudmodel.Status;
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteStudent(int Sid)
        {
            try
            {
                Student oldStud = dc.Students.First(S => S.Sid == Sid);
                oldStud.Status = false;
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}