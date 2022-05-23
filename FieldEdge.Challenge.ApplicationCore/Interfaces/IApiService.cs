using FieldEdge.Challenge.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FieldEdge.Challenge.ApplicationCore.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<CustomerModel>> GetCustomerList();
        Task<bool> CreateCustomer(CustomerModel model);
        Task<CustomerModel> GetCustomerById(string id);
        Task<bool> UpdateCustomer(CustomerModel model);
        Task<bool> DeleteCustomerById(string id);
    }
}
