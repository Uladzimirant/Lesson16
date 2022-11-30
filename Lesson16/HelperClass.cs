using static Lesson6.ProductsClassRealization.Chemical;

namespace Lesson16
{
    public static class HelperClass
    {
        public static string EnumMessage<T>(string t) where T : struct, System.Enum
        {
            return $"No such element - {t}. Avaliable: {string.Join(",", Enum.GetValues<T>())}";
        }
    }
}
