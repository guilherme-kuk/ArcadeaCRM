
using CrmApp.Application.Interfaces;
using CrmApp.Domain.Entities;
using CrmApp.Web.Constants;
using Microsoft.AspNetCore.Mvc;

namespace CrmApp.Web.Controllers
{
    [ApiController]
    [Route(ApiRoutes.BaseRoute + "/[controller]")]
    public class AccountsController(IAccountService accountService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Account>> GetAllAccountsAsync()
        {
            var accounts = await accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccountByIdAsync(int id)
        {
            var account = await accountService.GetAccountByIdAsync(id);
            if (account == null)
                return NotFound(new { Message = "Account not found." });

            return Ok(account);
        }

        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccountAsync(Account account)
        {
            var result = await accountService.CreateAccountAsync(account);
            if (!result.Success)
                return BadRequest(new { Message = result.Error });

            return CreatedAtAction(
                nameof(GetAccountByIdAsync),
                new { id = result.Account!.Id },
                result.Account
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccountAsync(int id, Account account)
        {
            if (id != account.Id)
                return BadRequest(new { Message = "ID mismatch." });

            var (success, error) = await accountService.UpdateAccountAsync(account);

            if (!success)
                return BadRequest(new { Message = error });

            return Ok(new { Message = "Account updated successfully." });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountAsync(int id)
        {
            var (success, error) = await accountService.DeleteAccountAsync(id);
            if (!success)
                return BadRequest(new { Message = error });

            return Ok(new { Message = "Account deleted successfully." });
        }
    }
}