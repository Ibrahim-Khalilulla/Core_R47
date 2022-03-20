using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_R47.Controllers
{
    public class MyStudent10
    {
        public int id { get; set; }
        public string name { get; set; }
        public string cname { get; set; }
    }
    public class ActionParameters : Controller
    {
        public IActionResult Index()
        {
            string a = "hello";
            return Ok(a);
            //https://localhost:44302/ActionParameters
        }
        public IActionResult two(string id)
        {
            return Ok(id);
            //https://localhost:44302/ActionParameters/two/21342213232
            //https://localhost:44302/ActionParameters/two?id=21342213232
            //if you use id as ActionParameters, you may not use it as Queryable string
        }
        public IActionResult three(int number)
        {
            return Ok(number);
            //https://localhost:44302/ActionParameters/three?number=1231313
        }
        public ActionResult four(int id, string name)
        {
            return Ok($"ID is: {id} and Name is: {name}");
            //https://localhost:44302/ActionParameters/four?id=123&name=karim
            //https://localhost:44302/ActionParameters/four/123?name=karim
        }
        public ActionResult five(MyStudent10 m)
        {
            return Ok(m);
            //output will be in json format
            //in route url class name MyStudent10 cannot be used, the properties of MyStudent10(id,name,cname will be used as query string)
            //https://localhost:44302/ActionParameters/five?id=123&name=karim&cname=six
            //https://localhost:44302/ActionParameters/five/123?name=karim&cname=six
        }
        public ActionResult six([FromQuery]int id)
        {
            return Ok(id);
            //https://localhost:44302/ActionParameters/six?id=123--valid
            //https://localhost:44302/ActionParameters/six/123--not valid
        }
        public ActionResult seven([FromHeader] int id)
        {
            return Ok(id);
            //run the url in postman, input of id is from headers> in header section, show Hide Auto-generated header>Select Postmane-Tken, Content-Type, Content-Length, Host, User Agent, Accept
            //https://localhost:44302/ActionParameters/seven
        }
        public ActionResult eight([FromBody] MyStudent10 id)
        {
            return Ok(id);
            //parameter must be a class
            //in route url class name MyStudent10 cannot be used, the properties of MyStudent10(id,name,cname will be used as query string)
            //in header section, show Hide Auto-generated header>Select Postman-Token, Content-Type:"application/json", Content-Length, Host, User Agent, Accept
            //run the url in postman, input of id is from body>raw>{"id":123,"name":"jello","cname":"six"} 
            //Method: Get, https://localhost:44302/ActionParameters/eight
        }
        [HttpPut]
        public ActionResult nine([FromBody] MyStudent10 id)
        {
            return Ok(id);
            //parameter must be a class
            //in route url class name MyStudent10 cannot be used, the properties of MyStudent10(id,name,cname will be used as query string)
            //in header section, show Hide Auto-generated header>Select Postman-Token, Content-Type:"application/json", Content-Length, Host, User Agent, Accept
            //run the url in postman, input of id is from body>raw>{"id":123,"name":"jello","cname":"six"} 
            //Method: Put, Url: https://localhost:44302/ActionParameters/eight
        }
    }
    }
