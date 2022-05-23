using AutoMapper;
using FieldEdge.Challenge.ApplicationCore.Models;
using FieldEdge.Challenge.Models;

namespace FieldEdge.Challenge.MapperConfig
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                // Application settings
                cfg.CreateMap<CustomerModel, CustomerViewModel>();
                cfg.CreateMap<CustomerViewModel, CustomerModel>();
            });
        }
    }
}
