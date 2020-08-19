using AutoMapper;
using FunctionalDatabase.Shared.DataTransferObjects;
using FunctionalDatabase.Shared.Models;

namespace FunctionalDatabase.Shared.MappingProfiles
{
    public class NorthwindProfile : Profile
    {
        public NorthwindProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<OrderDetail, OrderDetailsDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Region, RegionDto>();
            CreateMap<Shipper, ShipperDto>();
            CreateMap<Supplier, SupplierDto>();
            CreateMap<Territory, TerritoryDto>();
        }
    }
}