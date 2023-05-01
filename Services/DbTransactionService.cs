using Microsoft.EntityFrameworkCore.Storage;

namespace DigitalTwinMiddleware.Services
{
    public interface IDbTransactionService
    {
        ValueTask<IDbContextTransaction> BeginTransactionAsync();
    }
    public class DbTransactionService : IDbTransactionService
    {
        private readonly IRepository repository;

        public DbTransactionService(IRepository repository)
        {
            this.repository = repository;
        }

        public ValueTask<IDbContextTransaction> BeginTransactionAsync()
        {
            return repository.BeginTransactionAsync();
        }

    }
}
