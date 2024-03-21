namespace Assignment;

public class Product
{
    public int Code { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product(int code, string name, double price, int quantity)
    {
        Code = code;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}