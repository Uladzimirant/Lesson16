using Lesson6.ProductsClassRealization;
using System.Linq;

namespace Lesson16.Models.Domain
{
    [Serializable]
    public class ProductListDataModel
    {
        [Serializable]
        public struct ProductObject
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public double Amount { get; set; }
            public double ExpirationTime { get; set; }
            public double Voltage { get; set; }
            public double Amperage { get; set; }
            public double Power { get; set; }
            public string DangerLevel { get; set; }
        }
        public List<ProductObject> Products { get; set; }

        private Product ProductObjectToProduct(in ProductObject prod, bool ignoreIncorrectType = true)
        {
            if (Enum.TryParse<Product.ProductType>(prod.Type, out var type))
            {
                switch (type)
                {
                    case Product.ProductType.Food:
                        return new Food(prod.Name,
                            Convert.ToDecimal(prod.Price),
                            Convert.ToUInt32(prod.ExpirationTime),
                            Convert.ToSingle(prod.Amount)
                            );
                    case Product.ProductType.ElectricalAppliance:
                        return new ElectricalAppliance(prod.Name,
                            Convert.ToDecimal(prod.Price),
                            Convert.ToSingle(prod.Voltage),
                            Convert.ToSingle(prod.Amperage),
                            Convert.ToSingle(prod.Power),
                            Convert.ToUInt32(prod.Amount)
                            );
                    case Product.ProductType.Chemical:
                        if (Enum.TryParse<Chemical.DangerLevelType>(prod.DangerLevel, out var level))
                        {
                            return new Chemical(prod.Name,
                                Convert.ToDecimal(prod.Price),
                                level,
                                Convert.ToUInt32(prod.Amount)
                                );
                        }
                        else
                        {
                            return ignoreIncorrectType ? null : throw new FormatException($"There is no danger level: {prod.DangerLevel}");
                        }
                    case Product.ProductType.General:
                        return new Product(prod.Name,
                            Convert.ToDecimal(prod.Price),
                            Convert.ToUInt32(prod.Amount)
                            );
                    default:
                        return ignoreIncorrectType ? null : throw new FormatException($"There is no type: {prod.Type}");
                }
            }
            else
            {
                return ignoreIncorrectType ? null : throw new FormatException($"There is no type: {prod.Type}"); ;
            }
        }
        public List<Product> ConvertToProducts(bool ignoreIncorrectType = true)
        {
            return Products.Select(e => ProductObjectToProduct(e, ignoreIncorrectType)).Where(e => e != null).ToList();
        }
    }
}
