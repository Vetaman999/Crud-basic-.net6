using AutoMapper;
using prueba.Domain.Models;
using prueba.Resources;

namespace prueba.Mapping
{
    public class ModelToResourceProfile : Profile 
    {
        public ModelToResourceProfile() 
        {
            CreateMap<Product, ProductResource>();
        }
    }
}
