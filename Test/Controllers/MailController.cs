using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Test.Services;
using Test.ViewModels;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        public IConfiguration Configuration;
        public MailController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        public IActionResult send(MailViewModel mailViewModel) 
        {
            var mail = new MailService();
            string result = mail.sendMail(mailViewModel.FullName, mailViewModel.Email, mailViewModel.Subject, mailViewModel.Body, Configuration);
            if (result == "success")
                return Ok();
            else
                return BadRequest();
        }

    }
}