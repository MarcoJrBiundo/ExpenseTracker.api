using System;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using ExpenseTracker.Infrastructure.Persistence;

namespace ExpenseTracker.Infrastructure.Repositories;

public class ExpensesRepository(ExpensesDbContext dbContext) : IExpenseRepository
{
    public Task<Guid> AddExpenseAsync(Expense expense, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteExpenseAsync(Expense expense, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Expense?> GetExpenseByIdAsync(Guid userId, Guid expenseId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Expense>> GetExpensesByUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
