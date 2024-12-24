using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConsumer2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
    }
}