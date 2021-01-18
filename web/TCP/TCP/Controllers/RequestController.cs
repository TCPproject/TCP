using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        public async Task<RequestController> Get()
        {
            string curmail = User.Identity.Name;
            string Data = Request.Form["CurScore"].FirstOrDefault();
            IQueryable<User> queryables = _context.Users.Where(u => u.Email == curmail);
            if (queryables == null)
            {
                return null;
            }
            else
            {
                queryables.FirstOrDefault().Highscore = int.Parse(Data);
                _context.Update(queryables.FirstOrDefault());
                _context.SaveChanges();
            }
            return null;
        }

    }
}
