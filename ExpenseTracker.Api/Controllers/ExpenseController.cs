
using ExpenseTracker.Application.Expenses.Commands.CreateExpense;
using ExpenseTracker.Application.Expenses.Commands.DeleteExpense;
using ExpenseTracker.Application.Expenses.Commands.UpdateExpense;
using ExpenseTracker.Application.Expenses.Dtos;
using ExpenseTracker.Application.Expenses.Queries.GetExpenseByIdQuery;
using ExpenseTracker.Application.Expenses.Queries.GetExpensesByUserQuery;
using MediatR;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers
{
    [ApiController]
    [Route("api/users/{userId:guid}/expenses")]
    public class ExpenseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId : guid}")]
        public async Task<IActionResult> GetExpensesByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
              var expenses = await _mediator.Send(new GetExpensesByUserQuery(userId), cancellationToken);
             return Ok(expenses);
        }

        
        [HttpGet("{userId}/{expenseId}")]
        public async Task<IActionResult> GetExpenseByIdAsync(Guid userId, Guid expenseId, CancellationToken cancellationToken)
        {
             var expense = await _mediator.Send(new GetExpenseByIdQuery(userId, expenseId), cancellationToken);
             return Ok(expense);
        }   
      
        [HttpPost]
        public async Task<IActionResult> CreateExpenseAsync([FromBody] CreateExpenseRequestDto request, CancellationToken cancellationToken)
        {
            var expense = await _mediator.Send(new CreateExpenseCommand(  request.UserId,
                request.Amount,
                request.Currency,
                request.Category,
                request.Date,
                request.Description ), cancellationToken);
             return Ok(expense);
        }
       
        [HttpPut("{expenseId:guid}")]
        public  async Task<IActionResult> UpdateExpense(
           [FromRoute] Guid UserId, 
           [FromRoute] Guid expenseId,
           [FromBody] ExpenseDto request,
           CancellationToken cancellationToken)
        {

            if (request.Id != Guid.Empty && request.Id != expenseId)
            {
                return BadRequest("Route expenseId does not match body Id.");
            }

         var command = new UpdateExpenseCommand(
            UserId: UserId,
            ExpenseId: expenseId,
            Amount: request.Amount,
            Currency: request.Currency,
            Category: request.Category,
            Description: request.Description,
            Date: request.Date);

        var result = await _mediator.Send(command, cancellationToken);

        if (!result.Success)
        {
            return NotFound(result.ErrorMessage);
        }

        return NoContent();
        }
     
    [HttpDelete("{expenseId:guid}")]
        public async Task<IActionResult> DeleteExpense(
            [FromRoute] Guid userId,
            [FromRoute] Guid expenseId,
            CancellationToken cancellationToken)
        {
            var command = new DeleteExpenseCommand(userId, expenseId);

            var result = await _mediator.Send(command, cancellationToken);

            if (!result.Success)
            {
                return NotFound(result.ErrorMessage);
            }

            return NoContent();
        }

    }
}
