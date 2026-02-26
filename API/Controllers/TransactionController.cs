using Business.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

            return Ok();
        }

        [Authorize]
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] CreateDepositDTO dto)
        {
            return Ok();
        }

        [Authorize]
        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] CreateWithdrawDTO dto)
        {
            return Ok();
        }
    }