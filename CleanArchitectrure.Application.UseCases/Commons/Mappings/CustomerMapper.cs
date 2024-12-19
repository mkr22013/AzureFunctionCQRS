using AutoMapper;
using CleanArchitectrure.Application.Dto;
using CleanArchitectrure.Application.UseCases.Customers.Commands.CreateCustomerCommand;
using CleanArchitectrure.Application.UseCases.Customers.Commands.UpdateCustomerCommand;
using CleanArchitectrure.Domain.Entities;

namespace CleanArchitectrure.Application.UseCases.Commons.Mappings
{
    /// <summary>
    /// CustomerMapper - Automapper
    /// </summary>
    public class CustomerMapper: Profile
    {
        /// <summary>
        /// CustomerMapper constructor  
        /// </summary>
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
        }
    }
}
