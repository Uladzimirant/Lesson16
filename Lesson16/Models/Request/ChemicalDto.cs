using Lesson6.ProductsClassRealization;
using static Lesson6.ProductsClassRealization.Chemical;

namespace Lesson16.Models.Request
{
    public class ChemicalDto : ProductDto
    {
        public uint ExpirationTime { get; set; }
        public string DangerLevel { get; set; }

        public override Product ToProduct()
        {
            if (Enum.TryParse<DangerLevelType>(DangerLevel, out var level))
            {
                return new Chemical(Name, Price, level, Amount);
            }
            else throw new ArgumentException(HelperClass.EnumMessage<DangerLevelType>(DangerLevel));
        }
    }
}
