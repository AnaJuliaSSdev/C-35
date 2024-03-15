namespace PointOfSale
{
    internal class Product
    {
        public int Code { get; }
        public string Name { get; set; }
        public double Price { get; }

        public Product(int code, string name, double price)
        {
            Code = code;
            Name = name;
            Price = price;
        }
    }
}
