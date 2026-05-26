using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenga.OopAdv.Class08.EventsPublSub.Entities
{
    public class Market
    {
        public delegate void PromotionSender(ProductType productType);
        public delegate void InformationSender(string info);

        private event PromotionSender Promotions;
        private event InformationSender Information;

        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public List<string> ZalbiIPopolaki { get; set; }
        public List<string> Emails { get;set; }

        public Market()
        {
            ZalbiIPopolaki = new List<string>();
            Emails = new List<string>();
        }

        private void Send()
        {
            Promotions(ProductType);
        }

        public void SendPromotions()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine($"{Name} is sendig promotion for {ProductType}");
            Console.WriteLine("..........Sending......");
            Thread.Sleep(3000);
            Send();
        }

        public void SubscribeForPromotions(PromotionSender sub, string email)
        {
            Promotions += sub;
            Emails.Add(email);
        }
        public void SubscribeForInformation(InformationSender info, string email)
        {
            Information += info;
            Emails.Add(email);
        }

        public void UnsubscribeForPromotions(PromotionSender sub, string reason)
        {
            Promotions -= sub;
            ZalbiIPopolaki.Add(reason);
        }
        public void ReadZalbiIPoplaki()
        {
            Console.WriteLine($"[{Name}] ZALBI I POPLAKI");
            foreach (string zalbi in ZalbiIPopolaki)
            {
                Console.WriteLine(zalbi);
            }
        }
    }


    public enum ProductType
    {
        Food = 1,
        Cosmetics,
        Electronics,
        Other
    }
}
