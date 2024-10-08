﻿using Customer.API.Repositories.Interfaces;
using Customer.API.Services.Interfaces;

namespace Customer.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;   
            
        }
        public async Task<IResult> GetCustomerByUserName(string username)
        => Results.Ok(await _repository.GetCustomerByUserNameAsync(username));

        public async Task<IResult> GetCustomersAsync()
        => Results.Ok(await _repository.GetCustomersAsync());   
    }
}
