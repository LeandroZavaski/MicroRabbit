using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MicroRabbit.Banking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _service;

        public BankingController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_service.GetAccounts());
        }

        [HttpPost]
        public ActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            _service.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
