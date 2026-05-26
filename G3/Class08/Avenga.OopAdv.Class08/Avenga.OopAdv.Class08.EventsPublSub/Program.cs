using Avenga.OopAdv.Class08.EventsPublSub.Entities;



//PUBLISHER
Market market = new Market()
{
    Name = "Vero",
    ProductType = ProductType.Food
};

Market market1 = new Market()
{
    Name = "Atva",
    ProductType = ProductType.Electronics,
};

//SUBSCRIBERS
User jill = new User()
{
    Name = "Jill Jillson",
    Age = 25,
    FavoriteProductType = ProductType.Food,
};

User ana = new User()
{
    Name = "Ana Aneska",
    Age = 20,
    FavoriteProductType = ProductType.Other
};


//Subscribe user to promotion
market.SubscribeForPromotions(jill.ReadPromotion, "jill.jillson@gmail.com");
market.SubscribeForPromotions(ana.ReadPromotion, "ana.aneska@yahoo.com");

//Market sends promotion
market.SendPromotions();

Console.WriteLine("==============");

//Ana unsubscribe
market.UnsubscribeForPromotions(ana.ReadPromotion, "Too many emails!");


market.ProductType = ProductType.Cosmetics;

market.SendPromotions();

market.ProductType = ProductType.Other;

market.SendPromotions();

Console.WriteLine("==============");
market.ReadZalbiIPoplaki();


Console.WriteLine("==============");

market1.SubscribeForPromotions(ana.ReadPromotion, "ana.aneska@yahoo.com");

market1.SendPromotions();
Console.WriteLine("==============");
