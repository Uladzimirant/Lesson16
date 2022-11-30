using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6.ProductsClassRealization
{
    public class ElectricalAppliance : Product
    {
        public float Voltage { get; private set; }
        public float Amperage { get; private set; }
        public float Power { get; private set; }

        public override float Amount { 
            set {
                var temp = (uint)value;
                base.Amount = temp;
            } 
        }

        public ElectricalAppliance(string name, decimal price, float voltage, float amperage, float power, uint amount = 0) : base(name, price, amount)
        {
            Voltage = voltage;
            Amperage = amperage;
            Power = power;
            Type = ProductType.ElectricalAppliance;
        }
        public ElectricalAppliance(ElectricalAppliance other) : this(other.Name, other.Price, other.Voltage, other.Amperage, other.Power, (uint)other.Amount) { }
        public ElectricalAppliance(ElectricalAppliance other, uint amount) : this(other.Name, other.Price, other.Voltage, other.Amperage, other.Power, amount) { }

        public override string? ToString()
        {
            return base.ToString() + $", {Voltage} V, {Amperage} A, {Power} W";
        }
    }
}
