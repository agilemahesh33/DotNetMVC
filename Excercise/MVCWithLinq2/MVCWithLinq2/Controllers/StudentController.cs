using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithLinq2.Models;
using System.Configuration;
using System.IO;

namespace MVCWithLinq2.Controllers
{    
    public class StudentController : Controller
    {
        MVCDBDataContext dc = new MVCDBDataContext(ConfigurationManager.ConnectionStrings["MVCDBConnectionString"].ConnectionString);
        public ViewResult DisplayStudents()
        {
            return View(dc.Student_Select(null, true).ToList());
        }
        public ViewResult DisplayStudent(int Sid)
        {
            return View(dc.Student_Select(Sid, true).Single());
        }
        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddStudent(Student_SelectResult student,HttpPostedFileBase SelectedFile)
        {
            if (SelectedFile != null)
            {
                string directoryPath = Server.MapPath("~/Uploads/");
                if(!Directory.Exists(directoryPath)) 
                    Directory.CreateDirectory(directoryPath);
                SelectedFile.SaveAs(directoryPath+ SelectedFile.FileName);
                student.Photo = SelectedFile.FileName;
            }
            dc.Student_Insert(student.Sid, student.Name, student.Class, student.Fees, student.Photo);
            return RedirectToAction("DisplayStudents");
        }
        public ViewResult EditStudent(int? Sid)
        {
            var student = (dc.Student_Select(Sid, true)).Single();
            TempData["Photo"] = student.Photo;
            return View(student);
        }
        public RedirectToRouteResult UpdateStudent(Student_SelectResult student, HttpPostedFileBase SelectedFile)
        {
            if (SelectedFile != null)
            {
                string directoryPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                student.Photo = SelectedFile.FileName;
                SelectedFile.SaveAs(directoryPath + SelectedFile.FileName);
            }
            else
                student.Photo = TempData["Photo"].ToString();
            dc.Student_Update(student.Sid, student.Name, student.Class, student.Fees, student.Photo);
            return RedirectToAction("DisplayStudents");
        }
        public RedirectToRouteResult DeleteStudent(int? Sid)
        {
            dc.Student_Delete(Sid);
            return RedirectToAction("DisplayStudents");
        }
    }
}