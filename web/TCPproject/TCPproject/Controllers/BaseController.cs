
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace TCPproject.Controllers
{
    public class BaseController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            ViewData["Current"] = 1;
            return View();
        }
    }
}