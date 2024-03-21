namespace Assignment;

public class Inventory
{
    public List<Product> Products { get; set; }

    public Inventory()
    {
        Products = new List<Product>

        {
           new Product( 1, "Snickers", 10, 5),
            new Product(2, "Plopp", 8, 5),
            new Product(3, "M&M's", 10, 5),
            new Product(4, "Kit Kat", 10, 5),
            new Product(5, "Pringles", 15, 5),
            new Product(6, "Orbit Spearmint", 8, 5),
            new Product(7, "TicTac", 10, 5),
            new Product(8, "Coca-Cola Zero", 12, 5),
            new Product(9, "Sprite", 12, 5),
            new Product(10, "Bottled water", 10, 5)
        };
    }
}