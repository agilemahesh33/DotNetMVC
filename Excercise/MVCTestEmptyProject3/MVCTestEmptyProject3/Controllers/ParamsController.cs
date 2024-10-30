using System;
using System.Collections.Generic;
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
    }
}