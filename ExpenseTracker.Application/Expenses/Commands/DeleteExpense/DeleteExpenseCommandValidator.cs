using ExpenseTracker.Application.Expenses.Commands.DeleteExpense;
using FluentValidation;

public class DeleteExpenseCommandValidator : AbstractValidator<DeleteExpenseCommand>
{
    public DeleteExpenseCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.");

        RuleFor(x => x.ExpenseId)
            .NotEmpty()
            .WithMessage("ExpenseId is required.");
    }
}