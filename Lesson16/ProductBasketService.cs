using Lesson16.Models.Domain;
using Lesson6.ProductsClassRealization;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Lesson16
{
    public class ProductBasketService : ProductBasket
    {
        private static List<Product> ConvertToProducts(IOptions<ProductBasketSettings> settings, ILogger<ProductBasketService> log)
        {
            try
            {
                log.LogInformation("Trying read products json");
                using (var file = File.Open(settings.Value.FilePath, FileMode.Open))
                {
                    var t = JsonSerializer.Deserialize<ProductListDataModel>(file)?.ConvertToProducts(ignoreIncorrectType:false) ??
                        throw new JsonException($"Got null as result of deserializing file {file}");
                    log.LogInformation("Successfully deserialized products json");
                    return t;
                }
            }
            catch (JsonException e)
            {
                log.LogError($"Couldn't read json file: {e}");
                return new List<Product>();
            }
            catch (FileNotFoundException e) 
            {
                log.LogError($"Couldn't read json file: {e}");
                return new List<Product>();
            }
        }

        private readonly ILogger<ProductBasketService> _log;
        public ProductBasketService(IOptions<ProductBasketSettings> settings, ILogger<ProductBasketService> log) 
            : base(ConvertToProducts(settings, log))
        {
            _log = log;
            log.LogInformation("Started");
        }
    }
}
