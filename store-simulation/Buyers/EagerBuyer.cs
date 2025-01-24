using Assignment1.Shop;

namespace Assignment1.Buyers
{
    public class EagerBuyer : Buyer
    {
        public EagerBuyer(Card card, double budget) : base(card, budget)
        {

        }

        public override void VisitStores(List<Store> stores)
        {
            foreach (var store in stores)
            {
                foreach (var wish in wishList.ToList())
                {
                    if (Inquire(store, wish))
                    {
                        Product product = wish.GetProduct();
                        int count = wish.GetCount();
                        double price = store.GetPrice(product, card);
                        if (price > 0)
                        {
                            if (CanAfford(price, count))
                            {
                                store.SellProduct(product, count, this);
                            }
                        }
                    }
                }
            }
        }
    }
}
