namespace Assignment
{
    public class User
    {
        public string Name { get; set; }
        public List<Product> BoughtItems { get; } = new List<Product>();

        public Bank BankAccount { get; }    
        
        public User(string name, Bank bank)
        {
            Name = name;
            BankAccount = bank;
        }

        public void PurchaseProduct(Product product)
        {
            if (BankAccount.Money >= product.Price)
            {
                BoughtItems.Add(product);
                BankAccount.Money -= (int)product.Price;
                product.Quantity--;
                Console.WriteLine($"Successfully purchased {product.Name}. Your current balance: {BankAccount.Money} SEK.");
            }
            else
            {
                Console.WriteLine("You do not have enough money :(");
            }
        }
    }
}