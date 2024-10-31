using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestEmptyProject3.Controllers
{
    public class ParamsController : Controller
    {
        //We can pass the parameters to the controller using Route parameters as
        //Passsing value to Index1 Action method is mandatory 
        // If we dont pass it then it will throw error
        public string Index1(int id)
        {
            return "Index1(int id) :The value of Id is : " + id + " from Params controller";
        }
        //Passing value to Action menthod using default value if we pass then it will override 
        //the defualt value else default value will be shown
        public string Index2(int id = 0)
        {
            return "Index2(int id = 0) :The value of Id (defualt) is : " + id + " from Params controller";
        }
        //Passing value to Action method using null value
        //If we pass value then it will be considered 
        //If we dont pass the value then it will be null only
        public string Index3(int? id)
        {
            return "Index3(int? id) :The value of Id is (null) : " + id + " from Params controller";
        }
        public string Index4(int x)
        {
            //error because there is no x parameter in routeconfig.cs
            return "Index4(int x) The value of Id is (null) : " + x + " from Params controller"; 
        }
        public string Index5(int? x)
        {
            return "Index5(int? x) The value of Id is (null) : " + x + " from Params controller";
        }
        public string Index6(string id)
        {
            return "Index6(string id) The value of Id is (null) : " + id + " from Params controller";
        }
        public string Index7(int id, string name)
        {
            return $"Index7(int id, string name) Value of Id : {id} and Name : {name}"; 
        }
        public string Index8(int? id, string name)
        {
            return $"Index8(int? id, string name) Value of Id : {id} and Name : {name}";
        }
        public string Index9(int id, string pName, double pRice)
        {
            return $"PID : {id}, PName : {pName} , Price : {pRice}";
        }
        public string Index10()
        {
            int pid = int.Parse(Request.QueryString["id"]);
            string PName = Request.QueryString["name"];
            double price = double.Parse(Request.QueryString["price"]);
            return $"PID : {pid}, PName : {PName} , Price : {price}";
        }
        public string validate1()
        {
            string Name = Request.QueryString["name"];
            string pwd = Request.QueryString.Get("password");
            if (Name == "Mahesh" && pwd == "Mahesh")
                return "Valid User";
            else
                return "Invalid User";
        }
        public string validate2(string Name, string password)
        {
            if (Name == "Mahesh" && password == "Mahesh")
                return "Valid User";
            else
                return "Invalid User";
        }
    }
}