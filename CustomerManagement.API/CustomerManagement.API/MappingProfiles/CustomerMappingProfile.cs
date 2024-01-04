using AutoMapper;
using CustomerManagement.Business.ViewModels;
using CustomerManagement.Models;

namespace CustomerManagement.API.MappingProfiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<AddCustomerViewModel, Customer>()
                .ForMember(dest => dest.Identifier, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());

            CreateMap<UpdateCustomerViewModel, Customer>()
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());
        }
    }
}
