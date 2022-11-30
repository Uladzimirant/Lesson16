using Lesson6.ProductsClassRealization;

namespace Lesson16.Models.Request
{
    public class ElectricalApplianceDto : ProductDto
    {
        public float Voltage { get; set; }
        public float Amperage { get; set; }
        public float Power { get; set; }

        public override Product ToProduct()
        {
            return new ElectricalAppliance(Name, Price, Voltage, Amperage, Power, (uint)Amount);
        }
    }
}
