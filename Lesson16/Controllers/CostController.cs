using Microsoft.AspNetCore.Mvc;
using Lesson6.ProductsClassRealization;
using Lesson16.Models.Request;
using System.Xml.Linq;


namespace Lesson16.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CostController : ControllerBase
    {
        private readonly ILogger<CostController> _log;
        private ProductBasketService _productBasket;

        public CostController(ProductBasketService productBasket, ILogger<CostController> log)
        {
            _productBasket = productBasket;
            _log = log;
        }

        [HttpGet("")]
        public IActionResult Calculate()
        {
            var totalCost = _productBasket.GetFullPrice();
            return Ok(totalCost);
        }

        [HttpGet("{type}")]
        public IActionResult Calculate(string type)
        {
            if (Enum.TryParse<Product.ProductType>(type, true, out var res))
            {
                var totalCost = _productBasket.GetPriceByType(res);
                return Ok(totalCost);
            } else { return BadRequest(HelperClass.EnumMessage<Product.ProductType>(type)); }
        }
    }
}
