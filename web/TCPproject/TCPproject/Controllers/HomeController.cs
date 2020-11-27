using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCPproject.Models;
using Microsoft.AspNetCore.Authorization;

namespace TCPproject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
