using AutoMapper;
using prueba.Domain.Models;
using prueba.Resources;

namespace prueba.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile() 
        {
            CreateMap<SaveProductResource, Product>();
        }
    }
}
