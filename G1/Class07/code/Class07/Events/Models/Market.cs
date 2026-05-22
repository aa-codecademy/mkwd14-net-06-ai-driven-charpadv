using Events.Enums;

namespace Events.Models
{
    // Represents a PUBLISHER in the event system.
    // The Market can send promotions to all subscribed users.
    internal class Market
    {
        // ===> Delegate
        // Defines the method signature required for subscribing to the Promotions event.
        public delegate void PromotionHandler(ProductType productType);

        // ===> Event
        // Keeps a list of subscribed methods to be called when promotions are sent.
        private event PromotionHandler OnPromotionSent; 

        public int Id { get; set; }
        public string Name { get; set; }
        // The type of product this market promotes.
        public ProductType ProductTypeOnPromotion { get; set; }
        // Stores the email addresses of subscribers.
        List<string> SubscribersEmails { get; set; } = [];
        List<string> UnsubscribeReasons { get; set; } = [];

        // Subscribes a user to promotions.
        // Adds the provided method to the Promotions event and stores the user's email.
        public void SubscribeForPromotion(PromotionHandler handler, string email)
        {
            OnPromotionSent += handler;
            SubscribersEmails.Add(email);
        }

        // Sends out promotions to all subscribers.
        // Thread.Sleep(2000) simulates that something is being done for 2 seconds
        public void SendPromotions()
        {
            Console.WriteLine("=================");
            Console.WriteLine($"Market {Name} is sending promotions for {ProductTypeOnPromotion}");
            Console.WriteLine("...Sending...");
            Thread.Sleep(2000);
            NotifySubscribers();
        }

        // This method triggers (raises) the Promotions event
        // It notifies all subscribers (methods that previously subscribed to the event)
        // and passes the current ProductType as a parameter to them
        // Each subscriber method will receive this ProductType and can react accordingly
        private void NotifySubscribers()
        {
            //OnPromotionSent(ProductTypeOnPromotion);
            OnPromotionSent?.Invoke(ProductTypeOnPromotion);
        }

    }
}
