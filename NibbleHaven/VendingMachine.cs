namespace Assignment
{
    public class VendingMachine
    {
        private readonly Inventory myInventory;
        private readonly User user;
        private readonly Bank bank;
        private readonly List<Product> purchasedProducts;
        private bool optionsDisplayed;
        
        public VendingMachine()
        {
            myInventory = new Inventory();
            bank = new Bank(100);
            user = new User("John Doe", bank);
            purchasedProducts = new List<Product>();
            optionsDisplayed = false;
        }

        public void Run()
        {
            DisplayWelcomeMessage();

            if (!optionsDisplayed)
            {
                DisplayOptions();
                optionsDisplayed = true;
            }

            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.White;
                Console.Write("What would you like to do? (Type the option's number, 'help' or 'quit'): ");
                Console.ResetColor();
                var input = Console.ReadLine().ToLower();
                Console.WriteLine();
                
                if (input == "help")
                {
                    DisplayOptions();
                }
                else if (input == "quit")
                {
                    break;
                }
                else if (int.TryParse(input, out int option) && option >= 1 && option <= 3)
                {
                    HandleOption(option);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\ud83c\udf08 Thank you, come again! \ud83c\udf08");
            Console.ResetColor();
        }
        
        private void DisplayWelcomeMessage()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\ud83c\udf08 Welcome to Nibble Haven \ud83c\udf08");
            Console.ResetColor();
            Console.WriteLine();
        }
        
        private void DisplayOptions()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Options:");
            Console.ResetColor();
            Console.WriteLine("1. Show products \ud83d\uded2");
            Console.WriteLine("2. Show purchased products \ud83c\udf6b");
            Console.WriteLine("3. Show account balance \ud83d\udcb0");
        }    
        
        private void HandleOption(int option)
        {
            switch (option)
            {
                case 1:
                    DisplayInventory();
                    MakePurchase();
                    break;
                case 2:
                    DisplayPurchasedProducts();
                    break;
                case 3:
                    DisplayUserBalance();
                    break;
            }
        }

        private void DisplayInventory()
        {
            Console.WriteLine("Code  | Product Name     | Price (SEK) | Quantity");
            Console.WriteLine("-----------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var product in myInventory.Products)
            { 
                Console.WriteLine($"{product.Code,-5} | {product.Name,-15} | {product.Price,-12} | {product.Quantity}");
            }
            Console.ResetColor();
            Console.WriteLine();
        }
        
        private void MakePurchase()
        {
            Console.Write("Enter the product code you wish to purchase: ");
            var chosenProductCodeString = Console.ReadLine();

            if (!int.TryParse(chosenProductCodeString, out int chosenProductCode))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            var productToPurchase =
                myInventory.Products.FirstOrDefault(p => p.Code == chosenProductCode);

            if (productToPurchase == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }
            
            if (productToPurchase.Quantity <= 0)
            {
                Console.WriteLine("Sorry, this product is out of stock.");
                return;
            }

            user.PurchaseProduct(productToPurchase);

            purchasedProducts.Add(productToPurchase);

            Console.WriteLine();
        }

        private void DisplayPurchasedProducts()
        {
            if (purchasedProducts.Count > 0)
            {
                Console.WriteLine("You have purchased the following products:");
                foreach (var product in purchasedProducts)
                {
                    Console.WriteLine($"- {product.Name}");
                }
            }
            else
            {
                Console.WriteLine("You have not purchased any products yet.");
            }
            Console.WriteLine();
        }
        
        private void DisplayUserBalance()
        {
            Console.WriteLine($"Your current balance: {user.BankAccount.Money} SEK.");
            Console.WriteLine();
        }

        
    }
}


