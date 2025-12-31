using Business.Interfaces;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] CreateTransferDTO dto)
        {
            TransactionResult result = await _service.TransferAsync(dto);

            return result.IsSuccess ? Ok(result) : BadRequest(result);

        }
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] CreateDepositDTO dto)
        {
            TransactionResult result = await _service.DepositAsync(dto);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] CreateWithdrawDTO dto)
        {
            TransactionResult result = await _service.WithdrawAsync(dto);

            return result.IsSuccess ? Ok(result) : BadRequest(result);


        }



    }
}
