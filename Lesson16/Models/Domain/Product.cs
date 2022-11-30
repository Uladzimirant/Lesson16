using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6.ProductsClassRealization
{
    public class Product
    {
        public enum ProductType
        {
            General,
            Food,
            ElectricalAppliance,
            Chemical
        }

        public string Name { get; private set; }
        public decimal Price { get; set; }

        private float _amount;
        public virtual float Amount { 
            get { return _amount; }
            set {
                if (value < 0.0f) throw new ArgumentException("Amount must be posititve");
                _amount = value;
            } }
        public ProductType Type { get; protected set; }

        public Product(string name, decimal price, float amount = 0.0f)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Amount = amount;
            Type = ProductType.General;
        }
        public Product(Product other) : this(other.Name, other.Price, other.Amount) { }
        
        public Product(Product other, float amount) : this(other.Name, other.Price, amount) { }

        public override string? ToString()
        {
            return Name + " - " + Amount.ToString() + " for " + Price.ToString() + " BYN";
        }
    }
}
