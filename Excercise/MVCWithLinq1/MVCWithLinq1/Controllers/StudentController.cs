using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithLinq1.Models;

namespace MVCWithLinq1.Controllers
{
    public class StudentController : Controller
    {        
        StudentDAL dal = new StudentDAL();
        #region Display
        public ViewResult DisplayStudents()
        {
            var student = dal.GetStudents(true);
            return View(student);
        }
        public ViewResult DisplayStudent(int Sid)
        {            
            return View(dal.GetStudent(Sid, true));
        }
        #endregion Display

        #region Insert 
        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddStudent(Student student,HttpPostedFileBase SelectedFile)
        {
            if (SelectedFile != null)
            {               
                string DirectoryPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(DirectoryPath))                
                    Directory.CreateDirectory(DirectoryPath);
                SelectedFile.SaveAs(DirectoryPath + SelectedFile.FileName);
                student.Photo = SelectedFile.FileName;
            }
            student.Status = true;
            dal.InsertStudent(student);
            return RedirectToAction("DisplayStudents");
        }

        #endregion Insert

        #region Edit and Update
        [HttpGet]
        public ViewResult EditStudent(int Sid)
        {
            Student student = dal.GetStudent(Sid, true);            
            TempData["Photo"] = student.Photo;
            return View(student);
        }
        [HttpPost]
        public RedirectToRouteResult EditStudent(Student student, HttpPostedFileBase SelectedFile)        
        {
            if (SelectedFile != null)
            {
                string DirectoryPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(DirectoryPath))
                    Directory.CreateDirectory(DirectoryPath);
                SelectedFile.SaveAs(DirectoryPath + SelectedFile.FileName);
                student.Photo = SelectedFile.FileName;
            }
            else
                student.Photo = TempData["Photo"].ToString();
            student.Status = true;
            dal.UpdateStudent(student);
            return RedirectToAction("DisplayStudents");
        }

        #endregion Edit and Update

        #region Delete
        public RedirectToRouteResult DeleteStudent(int Sid)
        {
            dal.DeleteStudent(Sid);
            return RedirectToAction("DisplayStudents");
        }
        #endregion Delete
    }
}