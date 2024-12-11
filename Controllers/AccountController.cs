using Microsoft.AspNetCore.Mvc;
using BankAccountManagement.Interfaces;
using BankAccountManagement.Models;
using Microsoft.IdentityModel.Tokens;


namespace BankAccountManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)

        {
            _accountRepository = accountRepository;
        }

        [HttpPost]

        public IActionResult CreateAccount([FromBody] Account account)

        {
            int accountID = _accountRepository.CreateAccount(account);
            return CreatedAtAction(nameof(CreateAccount), new { id = accountID }, account);
        }

    }
}
