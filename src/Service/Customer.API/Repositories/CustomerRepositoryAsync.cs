using Contracts.Common.Interfaces;
using Customer.API.Persistence;
using Customer.API.Repositories.Interfaces;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.Repositories
{
    public class CustomerRepositoryAsync : RepositoryBaseAsync<Entities.Customer, int, CustomerContext>, ICustomerRepository
    {
        public CustomerRepositoryAsync(CustomerContext dbContext, IUnitOfWork<CustomerContext> unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public Task<Entities.Customer> GetCustomerByUserNameAsync(string username)
        => FindByCondition(x => x.UserName == username).SingleOrDefaultAsync();

        public async Task<IEnumerable<Entities.Customer>> GetCustomersAsync()
        {
            return await FindAll().ToListAsync();
        }
    }
}
