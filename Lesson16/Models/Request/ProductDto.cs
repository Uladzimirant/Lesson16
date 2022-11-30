using Lesson6.ProductsClassRealization;
using System.Xml.Linq;

namespace Lesson16.Models.Request
{
    public class ProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Amount { get; set; }

        public virtual Product ToProduct()
        {
            return new Product(Name, Price, Amount);
        }
    }
}
