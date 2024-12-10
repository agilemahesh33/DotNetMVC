using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using MVCWithEFDBF3.Models;

namespace MVCWithEFDBF3.Controllers
{
    public class StudentController : Controller
    {
        MVCDBEntities dc = new MVCDBEntities();
        public ViewResult DisplayStudents()
        {
            return View(dc.Student_Select(null, true).ToList());
        }
        public ViewResult DisplayStudent(int SID)
        {
            return View(dc.Student_Select(SID, true).Single());
        }
        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddStudent(Student_Select_Result student, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                string directoryPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                selectedFile.SaveAs(directoryPath + selectedFile.FileName);
                student.Photo = selectedFile.FileName;
            }
            dc.Student_Insert(student.Sid, student.Name, student.Class, student.Fees, student.Photo);
            return RedirectToAction("DisplayStudents");
        }
        [HttpGet]
        public ViewResult EditStudent(int SID)
        {
            var student = dc.Student_Select(SID, true).Single();
            TempData["Photo"] = student.Photo;
            return View(student);
        }
        [HttpPost]
        public RedirectToRouteResult EditStudent(Student_Select_Result student, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                string directoryPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                selectedFile.SaveAs(directoryPath + selectedFile.FileName);
                student.Photo = selectedFile.FileName;
            }
            else if (TempData["Photo"]!=null)
            {
                student.Photo = TempData["Photo"].ToString();
            }
            dc.Student_Update(student.Sid, student.Name, student.Class, student.Fees, student.Photo);
            return RedirectToAction("DisplayStudents");
        }
        [HttpGet]
        public ViewResult DeleteStudent(int SID)
        {
            return View(dc.Student_Select(SID, true).Single());
        }
        [HttpPost]
        public RedirectToRouteResult DeleteStudent(Student_Select_Result student)
        {
            dc.Student_Delete(student.Sid);
            return RedirectToAction("DisplayStudents");
        }
    }
}