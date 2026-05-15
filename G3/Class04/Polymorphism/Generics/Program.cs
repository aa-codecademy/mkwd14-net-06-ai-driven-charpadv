
using Generics.Domain;
using Generics.Domain.Models;

List<string> strings = new List<string>() { "Hello", "G3" };
List<int> ints = new List<int> { 1, 2, 3 };
List<bool> bools = new List<bool> { true, false };

NonGenericHelper.PrintListOfStrings(strings);
NonGenericHelper.PrintListOfInts(ints);
NonGenericHelper.PrintListOfBools(bools);

//here we pass on the type that will be placed in the placeholder T in genericHelper
GenericHelper<string>.PrintList(strings);
GenericHelper<int>.PrintList(ints);

//Just to show as an example, we made the GenericDb a non-static class
//T will be replaced with product for this instance of GenericDb
GenericDb<Product> productDb = new GenericDb<Product>();

Product product = new Product();
product.Id = 1;
product.Title = "Pizza";
product.Description = "Delicious";
productDb.Add(product); //genericDb is a non-static class, that's why here we use the instance(the object) to call the Add method and pass the product
						//GenericDb is a generic, but when we created the instance we said that this instance (productsDb) will be of type Product. So the T for this instance is replaced with Product

productDb.Add(new Product { Id = 2, Title = "Coca cola", Description = "Zero" });
productDb.PrintAll();

//T will be replaced with Order for this instance of GenericDb
GenericDb<Order> ordersDb = new GenericDb<Order>();

ordersDb.Add(new Order { Id = 1, OrderedBy = "Petko", Address = "Address1" });
ordersDb.PrintAll();

//GenericDb<int> integers = new GenericDb<int>(); //ERROR - we cannot convert the in into BaseEntity
