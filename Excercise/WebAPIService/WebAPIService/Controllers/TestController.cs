using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIService.Controllers
{
    public class TestController : ApiController
    {
        //As it is made static its single copy for every request
        //i.e. for all users only one copy will be available
        static List<string> Colors = new List<string>()
        {
            "Red","Blue","Green","Purple"
        };
        public IEnumerable<string> Get()
        {
            return Colors;
        }
        public string Get(int Id)
        {
            return Colors[Id];
        }
        public void post([FromBody] string color)
        {
            Colors.Add(color);
        }
        public void put(int Id, [FromBody] string color)
        {
            Colors[Id] = color;
        }
        public void delete(int Id)
        {
            Colors.RemoveAt(Id);
        }
    }
}
