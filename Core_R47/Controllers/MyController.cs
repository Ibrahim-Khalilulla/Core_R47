using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_R47.Models;
namespace Core_R47.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        [HttpPost]
        [Route("add")]
        public string Add([FromBody] MyClass p)
        {
            Response.ContentType = "Application/json";
            return "Name is " + p.content.ToString();
        }

    }
}
