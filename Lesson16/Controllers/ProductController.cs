using Microsoft.AspNetCore.Mvc;
using Lesson6.ProductsClassRealization;
using Lesson16.Models.Request;
using System.Xml.Linq;

namespace Lesson16.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _log;
        private ProductBasketService _productBasket;

        public ProductController(ProductBasketService productBasket, ILogger<ProductController> log)
        {
            _productBasket = productBasket;
            _log = log;
        }

        [HttpGet("")]
        public IActionResult Print()
        {
            return Ok(_productBasket.PrintProducts());
        }
        [HttpGet("{name}")]
        public IActionResult Print([FromRoute] string? name) 
        { 
            var p = _productBasket.Get(name);
            return p != null ? Ok(p) : NotFound();
        }

        [HttpGet]
        public IActionResult PrintByType(string type)
        {
            if (Enum.TryParse<Product.ProductType>(type, out var productType)) 
            {
                return Ok(_productBasket.PrintProductsByType(productType));
            } 
            else
            {
                return NotFound($"No such type - {type}");
            }
        }

        private IActionResult Add(ProductDto pdto)
        {
            var p = pdto.ToProduct();
            _productBasket.Add(p);
            _log.LogInformation($"Added product: {p}");
            return Created($"{p.Name}", p);
        }

        [HttpPost]
        public IActionResult AddGeneral(ProductDto p)
        {
            return Add(p);
        }

        [HttpPost]
        public IActionResult AddFood(FoodDto p)
        {
            return Add(p);
        }

        [HttpPost]
        public IActionResult AddElectricalAppliance(ElectricalApplianceDto p)
        {
            return Add(p);
        }

        [HttpPost]
        public IActionResult AddChemical(ChemicalDto p)
        {
            try
            {
                return Add(p);
            } 
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult ChangeAmount(string name, float amount)
        {
            if (_productBasket.SetAmount(name, amount))
            {
                _log.LogInformation($"Changed amount: {name}-{amount}");
                return Ok(_productBasket.Get(name));
            }
            else return NotFound($"No such element - {name}");
        }

        [HttpDelete]
        public IActionResult Delete(string name)
        {
            if (_productBasket.Remove(name)) _log.LogInformation($"Product {name} removed");
            return NoContent();
        }
    }
}