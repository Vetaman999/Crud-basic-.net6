using prueba.Domain.Models;

namespace prueba.Domain.Services.Comunications
{
    public class ProductResponse : BaseResponse<Product>
    {
        public ProductResponse(Product resource) : base(resource)
        {
        }
        public ProductResponse(string message) : base(message)
        {
        }
    }
}