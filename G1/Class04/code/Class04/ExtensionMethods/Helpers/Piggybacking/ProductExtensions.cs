using ExtensionMethods.Models;

/*
    *PIGGYBACKING* ===> techique of changing the namespace of entity (class), allowing it to be usable in the whole project without the need of adding an using.
    ===> Useful when using extensions
    ===> Be very cautious when using
*/

//namespace ExtensionMethods.Helpers.Piggybacking
namespace ExtensionMethods
{
    public static class ProductExtensions
    {
        public static void PrintInfo(this Product product)
        {
            Console.WriteLine(product.GetInfo());
        }
    }
}
