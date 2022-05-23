using FieldEdge.Challenge.ApplicationCore.Interfaces;
using FieldEdge.Challenge.ApplicationCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FieldEdge.Challenge.ApplicationCore.Services
{
    public class ApiService : IApiService
    {
        private readonly IServiceConfiguration _serviceConfiguration;
        public ApiService(IServiceConfiguration serviceConfiguration)
        {
            _serviceConfiguration = serviceConfiguration;
        }
        public async Task<IEnumerable<CustomerModel>> GetCustomerList()
        {
            var method = $"{_serviceConfiguration.URL}Customers";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_serviceConfiguration.URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync(method).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<List<CustomerModel>>(jsonString);

                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
        public async Task<bool> CreateCustomer(CustomerModel model)
        {
            var method = $"{_serviceConfiguration.URL}Customer";
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    
                    client.BaseAddress = new Uri(_serviceConfiguration.URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.PostAsync(method, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }
        public async Task<CustomerModel> GetCustomerById(string id)
        {
            var method = $"{_serviceConfiguration.URL}Customer/{id}";
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(_serviceConfiguration.URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.GetAsync(method);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CustomerModel>(jsonString);

                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }      
        public async Task<bool> UpdateCustomer(CustomerModel model)
        {
            var method = $"{_serviceConfiguration.URL}Customer/{model.Id}";
               
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(_serviceConfiguration.URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.PostAsync(method, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }
        public async Task<bool> DeleteCustomerById(string id)
        {
            var method = $"{_serviceConfiguration.URL}Customer/{id}";
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(_serviceConfiguration.URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.DeleteAsync(method);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
    }
}
