using Business.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TransactionController : ControllerBase
{
    readonly ITransactionService _service;

    public TransactionController(ITransactionService service)
    {
        _service = service;
    }

    int GetCurrentUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    [HttpPost("deposit")]
    public async Task<IActionResult> Deposit([FromBody] CreateDepositDTO dto)
    {
        var result = await _service.DepositAsync(GetCurrentUserId(), dto);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost("withdraw")]
    public async Task<IActionResult> Withdraw([FromBody] CreateWithdrawDTO dto)
    {
        var result = await _service.WithdrawAsync(GetCurrentUserId(), dto);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer([FromBody] CreateTransferDTO dto)
    {
        var result = await _service.TransferAsync(GetCurrentUserId(), dto);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}