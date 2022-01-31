using AutoMapper;
using MyProject.AdventureWorksOBP;
using MyProject.DTO;

namespace MyProject.App_Start
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            Mapper.CreateMap<Kupac, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Kupac>();
            Mapper.CreateMap<ProductDTO, Proizvod>();
            Mapper.CreateMap<Proizvod, ProductDTO>();
        }
    }
}