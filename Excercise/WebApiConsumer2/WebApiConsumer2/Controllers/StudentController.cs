using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiConsumer2.Models;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;
using System.IO;

namespace WebApiConsumer2.Controllers
{
    public class StudentController : Controller
    {
        HttpClient client = new HttpClient();
        string serviceUrl = ConfigurationManager.AppSettings.Get("WebApiUrl");
        public ViewResult DisplayStudents()
        {
            client.BaseAddress = new Uri(serviceUrl);
            Task<HttpResponseMessage> getTask = client.GetAsync("Student");
            getTask.Wait();
            HttpResponseMessage message = getTask.Result;
            List<Student> students = message.Content.ReadAsAsync<List<Student>>().Result;
            return View(students);
        }
        public ViewResult DisplayStudent(int Id)
        {
            client.BaseAddress = new Uri(serviceUrl);
            Task<HttpResponseMessage> getTask = client.GetAsync("Student/" + Id);
            getTask.Wait();
            HttpResponseMessage message = getTask.Result;
            Student student = message.Content.ReadAsAsync<Student>().Result;
            return View(student);
        }
        public ViewResult AddStudent()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult AddStudent(Student student, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                BinaryReader br = new BinaryReader(selectedFile.InputStream);
                student.Photo = br.ReadBytes(selectedFile.ContentLength);
            }
            client.BaseAddress = new Uri(serviceUrl);
            Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("Student", student);
            postTask.Wait();
            HttpResponseMessage message = postTask.Result;
            if (message.IsSuccessStatusCode)
            {
                return RedirectToAction("DisplayStudents");
            }
            else
            {
                return View();
            }
        }
        public ViewResult EditStudent(int Id)
        {
            client.BaseAddress = new Uri(serviceUrl);
            Task<HttpResponseMessage> getTask = client.GetAsync("Student/" + Id);
            getTask.Wait();
            HttpResponseMessage message = getTask.Result;
            Student student = message.Content.ReadAsAsync<Student>().Result;
            if (student.Photo != null)
            {
                Session["Photo"] = student.Photo;
            }
            return View(student);
        }
        public ActionResult UpdateStudent(Student student, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                BinaryReader br = new BinaryReader(selectedFile.InputStream);
                student.Photo = br.ReadBytes(selectedFile.ContentLength);
            }
            else if (Session["Photo"] != null)
            {
                student.Photo = (byte[])Session["Photo"];
            }
            client.BaseAddress = new Uri(serviceUrl);
            Task<HttpResponseMessage> putTask = client.PutAsJsonAsync<Student>("Student", student);
            putTask.Wait();
            HttpResponseMessage message = putTask.Result;
            if (message.IsSuccessStatusCode)
            {
                return RedirectToAction("DisplayStudents");
            }
            else
            {
                return View("EditStudent", student);
            }
        }
        public ActionResult DeleteStudent(int Id)
        {
            client.BaseAddress = new Uri(serviceUrl);
            Task<HttpResponseMessage> deleteTask = client.DeleteAsync("Student/" + Id);
            deleteTask.Wait();
            HttpResponseMessage message = deleteTask.Result;
            if (message.IsSuccessStatusCode)
            {
                return RedirectToAction("DisplayStudents");
            }
            else
            {
                return View();
            }
        }

    }
}