using Assignment1.Shop;

namespace Assignment1.Buyers
{
    public class LazyBuyer : Buyer
    {
        private int storeCount;

        public LazyBuyer(Card card, double budget, int storeCount) : base(card, budget)
        {
            this.storeCount = storeCount;
        }
        public override void VisitStores(List<Store> stores)
        {
            if (storeCount > stores.Count){
                storeCount = stores.Count;
            }
            for (var i = 0; i < storeCount; i++)
            {
                foreach (var wish in wishList.ToList())
                {
                    if (Inquire(stores[i], wish))
                    {
                        Product product = wish.GetProduct();
                        int count = wish.GetCount();
                        double price = stores[i].GetPrice(product, card);
                        if (price > 0)
                        {
                            if (CanAfford(price, count))
                            {
                                stores[i].SellProduct(product, count, this);
                            }
                        }
                    }
                }
            }
        }
    }
}
