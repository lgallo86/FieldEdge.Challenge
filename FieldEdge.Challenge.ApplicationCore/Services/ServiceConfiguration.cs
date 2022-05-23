using FieldEdge.Challenge.ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FieldEdge.Challenge.ApplicationCore.Services
{
    public class ServiceConfiguration : IServiceConfiguration
    {
        private static IConfiguration _configurationRoot;

        public ServiceConfiguration(IConfiguration configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public string URL => _configurationRoot["URL"];
    }
}
