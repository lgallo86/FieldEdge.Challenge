using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FieldEdge.Challenge.ApplicationCore.Interfaces;
using FieldEdge.Challenge.ApplicationCore.Models;
using FieldEdge.Challenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace FieldEdge.Challenge.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IApiService _apiService;


        public CustomerController(IApiService apiService)
        {
            _apiService = apiService;
        }
        
        public IActionResult Customers()
        {
            return View();
        }

        public async Task<List<CustomerViewModel>> GetCustomers()
        {
            var model = await _apiService.GetCustomerList();
            var result = Mapper.Map<List<CustomerModel>, List<CustomerViewModel>>(model.ToList());
            return result.ToList();
        }

        public IActionResult EditCustomers(string id)
        {
            var model = new CustomerViewModel
            {
                Id = id
            };
            return View(model);
        }
        public async Task<CustomerViewModel> GetCustomerById(string id)
        {
            var model = await _apiService.GetCustomerById(id);
            var result = Mapper.Map<CustomerModel,CustomerViewModel>(model);
            return result;
        }
        [HttpPost]
        public async Task<bool> EditCustomer (CustomerViewModel model)
        {
            try
            {
                var m = Mapper.Map<CustomerViewModel, CustomerModel>(model);
                if (String.IsNullOrEmpty(model.Id) || model.Id == "0")
                {
                   return await _apiService.CreateCustomer(m);
                }
                else
                {
                    return await _apiService.UpdateCustomer(m);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<bool> DeleteCustomer(string id)
        {
            var result = false;
            try
            {
                if (!String.IsNullOrEmpty(id))
                {
                    result = await _apiService.DeleteCustomerById(id);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
