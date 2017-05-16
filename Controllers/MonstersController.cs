using dotnetTest.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetTest.Controllers
{
    [Route("api/[controller]")]
    public class MonstersController : Controller
    {
        private IMonsterRepository monstersRepository;

        public MonstersController(IMonsterRepository monstersRepository)
        {
            this.monstersRepository = monstersRepository;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            return this.Ok(monstersRepository.All());
        }

        //TODO: implement MailKit to send a test mail
        [HttpGet]
        [Route("email")]
        public IActionResult SendEmail()
        {
            return this.Ok();
        }
    }
}
