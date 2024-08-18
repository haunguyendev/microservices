namespace Customer.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IResult> GetCustomerByUserName(string username);
        Task<IResult> GetCustomersAsync();
    }
}
