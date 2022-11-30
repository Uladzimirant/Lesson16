using Lesson6.ProductsClassRealization;

namespace Lesson16.Models.Request
{
    public class FoodDto : ProductDto
    {
        public uint ExpirationTime { get; set; }

        public override Product ToProduct()
        {
            return new Food(Name, Price, ExpirationTime, Amount);
        }
    }
}
