using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithADO.Models;

namespace MVCWithADO.Controllers
{
    public class StudentController : Controller
    {       
        StudentDAL dal = new StudentDAL();
        public ViewResult DisplayStudents()
        {
            return View(dal.SelectStudents(null, true));
        }
        public ViewResult DisplayStudent(int Sid)
        {
            var student = dal.SelectStudents(Sid, true)[0];
            return View(student);
        }
        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddStudent(Student student, HttpPostedFileBase selectedFile)
        {
            if(selectedFile!=null)
            {
                string directoryPath = Server.MapPath("~/Uploads");
                if(!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                selectedFile.SaveAs(directoryPath + selectedFile.FileName);
                student.Photo = selectedFile.FileName;
            }
            dal.InsertStudent(student);
            return RedirectToAction("DisplayStudents");
        }
        [HttpGet]
        public ViewResult EditStudent(int Sid)
        {
            var student = dal.SelectStudents(Sid, true)[0];
            TempData["Photo"] = student.Photo;
            return View(student);
        }
        [HttpPost]
        public RedirectToRouteResult UpdateStudent(Student student, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                string directoryPath = Server.MapPath("~/Uploads");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                selectedFile.SaveAs(directoryPath + selectedFile.FileName);
                student.Photo = selectedFile.FileName;
            }
            else if (TempData["Photo"] != null)
            {
                student.Photo = TempData["Photo"].ToString();
            }
            dal.UpdateStudent(student);
            return RedirectToAction("DisplayStudents");
        }
        public RedirectToRouteResult DeleteStudent(int Sid)
        {
            dal.DeleteStudent(Sid);
            return RedirectToAction("DisplayStudents");
        }
    }
}