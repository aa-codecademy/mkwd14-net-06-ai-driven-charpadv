using Events.Enums;
using Events.Models;

Console.WriteLine("\n============= SUPER MARKET =============\n");

// Create a new market instance
Market market = new Market
{
    Id = 1,
    Name = "Super Market",
    ProductTypeOnPromotion = ProductType.Electronics
};

// Create new user instances
User user1 = new User(1, "Bob Bobsky", "bobsky@mail.com", 24, ProductType.Electronics);
User user2 = new User(2, "John Doe", "john@mail.com", 26, ProductType.Food);
User user3 = new User(3, "Jane Bobsky", "jane@mail.com", 28, ProductType.Other);

// Subscribe user1 for promotion
market.SubscribeForPromotion(user1.ReadPromotion, user1.Email);
// Subscribe user2 for promotion
market.SubscribeForPromotion(user2.ReadPromotion, user2.Email);

// Send promotions
market.SendPromotions();

// Subscribe user3 for promotion
market.SubscribeForPromotion(user3.ReadPromotion, user3.Email);
// Send promotions (again)
market.SendPromotions();

Console.ReadLine();