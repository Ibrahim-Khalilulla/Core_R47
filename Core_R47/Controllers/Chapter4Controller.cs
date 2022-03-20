using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_R47.Controllers
{
    [Route("go/to/[action]/for")]
    public class Chapter4Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("{days:int}/days")]
        public IActionResult SanFrancisco(int days)
        {
            //https://localhost:44399/go/to/SanFrancisco/for/3/days
            var action = $"In {RouteData.Values["action"].ToString()} for {days} days";
            return Ok(action);
        }
        public ActionResult Echo()
        {
            // https://localhost:44399/go/to/echo/for?today=sunday
            var data = Request.Query["today"];
            return Ok(data);//json
        }
        [Route("text")]
        public IActionResult Repeat(string text, int number)
        {
            //parameters in action become query string in routes
            //https://localhost:44399/go/to/repeat/for/text?text=jamal&number=10
            var data = string.Format("Text:{0} Number:{1}", text, number);
            return Ok(data);
        }
        [Route("Name/{city}")]
        public IActionResult Visit([FromQuery] string city)
        {
            //[FromQuery] means city is a query string
            //if route and parameter has the same variable, parameter get priority
            //https://localhost:44399/go/to/Visit/for/Name/Chittagong?city=Ctg
            var data = string.Format("Text:{0}", city);
            return Ok(data);
        }
        [Route("Culture1/{language}")]
        public IActionResult Culture([FromHeader(Name = "Accept-Language")] string language)
        {
            //https://localhost:44399/go/to/culture/for/culture1/rsfdsf-asdsa
            var data = string.Format("Language:{0}", language);
            return Ok(data);
        }
        [Route("Print1")]
        [HttpGet]
        public IActionResult Print()
        {
       // https://localhost:44399/go/to/Print/for/Print1
            return View();
        }

    }
}
