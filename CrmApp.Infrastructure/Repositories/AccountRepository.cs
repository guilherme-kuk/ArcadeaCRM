using CrmApp.Domain.Entities;
using CrmApp.Domain.Interfaces;
using CrmApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CrmApp.Infrastructure.Repositories;

public class AccountRepository(CrmDbContext context) : IAccountRepository
{
    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        return await context.Accounts
            .AsNoTracking()
            .OrderByDescending(a => a.DateCreated)
            .ToListAsync();
    }

    public async Task<Account?> GetByIdAsync(int id)
    {
        return await context.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Account?> GetByEmailAsync(string email)
    {
        return await context.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<Account> AddAsync(Account account)
    {
        account.DateCreated = DateTime.UtcNow;
        context.Accounts.Add(account);
        await context.SaveChangesAsync();
        return account;
    }

    public async Task UpdateAsync(Account account)
    {
        var existingEntry = context.ChangeTracker.Entries<Account>()
            .FirstOrDefault(e => e.Entity.Id == account.Id);
        
        if (existingEntry is not null)
        {
            existingEntry.State = EntityState.Detached;
        }
        
        context.Accounts.Attach(account);
        context.Entry(account).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var existingEntry = context.ChangeTracker.Entries<Account>()
            .FirstOrDefault(e => e.Entity.Id == id);
        
        if (existingEntry is not null)
        {
            existingEntry.State = EntityState.Detached;
        }
        
        var account = new Account { Id = id };
        context.Accounts.Attach(account);
        context.Accounts.Remove(account);
        await context.SaveChangesAsync();
    }

    public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
    {
        return await context.Accounts
            .AsNoTracking()
            .AnyAsync(a => a.Email == email && (excludeId == null || a.Id != excludeId));
    }
}

