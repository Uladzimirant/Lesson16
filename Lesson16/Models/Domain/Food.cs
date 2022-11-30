using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6.ProductsClassRealization
{
    public class Food : Product
    {
        public uint ExpirationTime { get; private set; }
        public Food(string name, decimal price, uint expirationTime, float amount = 0.0f) : base(name, price, amount)
        {
            ExpirationTime = expirationTime;
            Type = ProductType.Food;
        }
        public Food(Food other) : this(other.Name, other.Price, other.ExpirationTime, other.Amount) { }
        public Food(Food other, float amount) : this(other.Name, other.Price, other.ExpirationTime, amount) { }

        public override string? ToString()
        {
            return base.ToString() + $", {ExpirationTime} day{(ExpirationTime > 1 ? "s" : "")}";
        }
    }
}
