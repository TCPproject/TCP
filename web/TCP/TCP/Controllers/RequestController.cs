using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCP.Models;

namespace TCP.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class RequestController : ControllerBase
    {

        private readonly UserContext _context;

        public RequestController(UserContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<RequestController> Get()
        {
            string Data = Request.Form["CurScore"].FirstOrDefault();
            
            _context.Users.FirstOrDefault().Highscore = int.Parse(Data);
            return Redirect("~/Game/CurUser");
        }

    }
}
