using Demo.Data.Models;
using Demo.Repositories.GenericRepository;

namespace Demo.Repositories.CustomerRepository
{
    public interface ICustomerRepo : IGenericRepo<Customer>
    {
        Task<IEnumerable<Customer>> GetAllCustomersWithInformation();
    }
}
