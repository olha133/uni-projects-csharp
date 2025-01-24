using Assignment1.Buyers;

namespace Assignment1.Shop
{
    public class Store
    {
        private List<Article> articles = new List<Article>();
        private double incomeRate;
        private double income;

        public Store(double incomeRate)
        {
            this.incomeRate = incomeRate;
            this.income = 0;
        }

        public List<double> GetArticles()
        {
            List<double> myValues = new List<double>();
            for (int i = 0; i < articles.Count; i++)
            {
                myValues.Add(articles[i].GetPrice());
            }
            return myValues;
        }
        public double GetIncome() { return income; }
        public int ArticleIdx(Product product)
        {
            return articles.FindIndex(x => x.GetProduct() == product);
        }
        public void StockProduct(Product product, int count, double discount)
        {
            int idx = ArticleIdx(product);
            if (idx != -1)
            {
                articles[idx].SetQuantity(articles[idx].GetQuantity() + count);
                articles[idx].SetDiscount(discount);
                articles[idx].SetIncomeRate(this.incomeRate);
            }
            else
            {
                Article newArticle = new Article(product, this.incomeRate, count, discount);
                articles.Add(newArticle);
            }
        }

        public void ApplyDiscountForCategory(ProductType category, double discount)
        {
            for (int x = 0; x < articles.Count(); x++)
            {
                if (articles[x].GetProduct().GetCategory() == category)
                {
                    articles[x].SetDiscount(discount);
                }
            }
        }

        public bool HasProduct(Product product, int count)
        {
            int idx = ArticleIdx(product);
            if (idx != -1)
            {
                if (articles[idx].CanSell(count)) { return true; }
                else { return false; }
            }
            else { return false; }
        }

        public double GetPrice(Product product, Card card)
        {
            int idx = ArticleIdx(product);
            if (idx != -1)
            {
                double price = articles[idx].GetPrice();
                if (card != null)
                {
                    if (card.IsValidFor(product.GetCategory()))
                    {
                        price *= (1 - card.GetDiscount());
                    }
                }
                return price;
            }
            else { return 0; }
        }

        public void SellProduct(Product product, int count, Buyer buyer)
        {
            int idx = ArticleIdx(product);
            if (idx != -1)
            {
                if (articles[idx].CanSell(count))
                {
                    double price = GetPrice(product, buyer.GetCard());
                    if (buyer.CanAfford(price, count))
                    {
                        articles[idx].Sell(count);
                        income += price;
                        buyer.SellTo(product, count, price);
                    }
                    else { return; }
                }
                else { return; }
            }
            else { return; }
        }
    }
}
