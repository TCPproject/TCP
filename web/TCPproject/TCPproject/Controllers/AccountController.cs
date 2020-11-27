using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TCPproject.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using TCPproject.Models; // пространство имен UserContext и класса User
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Google;
using System.Linq;

namespace TCPproject.Controllers
{
    [AllowAnonymous, Route("account")]
    public class AccountController : Controller
    {
        
        [Route("google-login")]
        public IActionResult GoogleLogin()
        {

            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault() 
        
        .Claims.Select(claim => new {
             claim.Issuer,
             claim.OriginalIssuer,
             claim.Type,
             claim.Value
         });
            return Json(claims);
        }
    }

}