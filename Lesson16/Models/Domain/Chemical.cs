using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6.ProductsClassRealization
{
    public class Chemical : Product
    {
        public enum DangerLevelType
        {
            Safe,
            Slight,
            Dangerous,
            Extreme
        }
        public DangerLevelType DangerLevel { get; private set; }

        public Chemical(string name, decimal price, DangerLevelType dangerLevel, float amount = 0.0f) : base(name, price, amount)
        {
            DangerLevel = dangerLevel;
            Type = ProductType.Chemical;
        }

        public Chemical(string name, decimal price, float amount = 0.0f) : this(name, price, DangerLevelType.Safe, amount) {}
        public Chemical(Chemical other) : this(other.Name,other.Price,other.DangerLevel,other.Amount) {}
        public Chemical(Chemical other, float amount) : this(other.Name, other.Price, other.DangerLevel, amount) { }
        public override string? ToString()
        {
            return base.ToString() + $", level of danger: {DangerLevel}";
        }
    }
}
