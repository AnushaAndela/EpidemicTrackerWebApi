using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicTracker.Api.Services;
using EpidemicTracker.data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginRepository _context;
        public LoginController(ILoginRepository context)
        {
            _context = context;
        }
        [Route("SignIn")]
        [HttpPost]
        public ActionResult<Login> PostSignIn(Login login)
        {
            var signin = _context.SignIn(login);
            if (signin != null)
            {
                return Ok(signin.LoginId);
            }
            return NotFound("Please Enter Your Email/Password Correctly.");
        }
    }
}