using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product
                {
                    Id=1,
                    Name="Product 1"
                },
                new Product
                {
                    Id=2,
                    Name="Product 2"                },
                new Product
                {
                    Id=3,
                    Name="Product 3"
                },
                new Product
                {
                    Id=4,
                    Name="Product 4"
                },
                new Product
                {
                    Id=5,
                    Name="Product 5"
                },
            };
            return products;
        }    
    }
}
