using Business.Interfaces;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        readonly ITransactionService _service;
            
        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] CreateTransferDTO dto)
        {
            int currentId = User.GetCurrentUserId();
            
            TransactionResult result = await _service.TransferAsync(currentId,dto);

            return result.IsSuccess ? Ok(result) : BadRequest(result);

        }

        [Authorize]
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] CreateDepositDTO dto)
        {
            int currentId = User.GetCurrentUserId();

            TransactionResult result = await _service.DepositAsync(currentId,dto);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [Authorize]
        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] CreateWithdrawDTO dto)
        {
            int currentId = User.GetCurrentUserId();

            TransactionResult result = await _service.WithdrawAsync(currentId, dto);

            return result.IsSuccess ? Ok(result) : BadRequest(result);


        }



    }
}
