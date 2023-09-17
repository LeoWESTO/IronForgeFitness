using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Application.Services;
using IronForgeFitness.Domain.Entities.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/payments")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly TransactionService _paymentService;

    public PaymentController(
        IMapper mapper,
        TransactionService paymentService)
    {
        _mapper = mapper;
        _paymentService = paymentService;
    }

    // GET api/payments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentGet>>> GetAll(
        uint page = 1,
        uint itemsPerPage = 10)
    {
        try
        {
            var payments = _mapper.Map<List<PaymentGet>>(await _paymentService.GetPaymentsAsync((int)page, (int)itemsPerPage));
            var res = new PaymentsList(page, itemsPerPage, (uint)await _paymentService.TotalCount(), payments);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/payments/{paymentId}
    [HttpGet("{paymentId}")]
    public async Task<ActionResult<PaymentGet>> Get(Guid paymentId)
    {
        try
        {
            var payment = await _paymentService.GetPaymentAsync(paymentId);
            var paymentDTO = _mapper.Map<PaymentGet>(payment);
            return Ok(paymentDTO);
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }

    // POST api/payments
    [HttpPost]
    public async Task<IActionResult> Create(PaymentPost paymentDTO)
    {
        try
        {
            var payment = _mapper.Map<Payment>(paymentDTO);
            await _paymentService.AddPaymentAsync(payment);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/payments
    [HttpPut]
    public async Task<IActionResult> Update(PaymentPut paymentDTO)
    {
        try
        {
            var payment = _mapper.Map<Payment>(paymentDTO);
            await _paymentService.UpdatePaymentAsync(payment);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/payments/{paymentId}
    [HttpDelete("{paymentId}")]
    public async Task<IActionResult> Delete(Guid paymentId)
    {
        try
        {
            await _paymentService.DeletePaymentAsync(paymentId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
}
