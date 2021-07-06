using Domain.ProductsDto;
using NodaMoney;

namespace Domain.Products
{
    public class Product
    {


        public string id { get; set; }
        public string description { get; set; }
        public int category { get; set; }
        public Money price { get; set; }
        

        
        public Product(ProductDto productDto)
        {
            id = productDto.id;
            description = productDto.description;
            category = productDto.category;
            price = new Money(productDto.price, "EUR");
        }

        public Product()
        {
        }
    }
    
    
}