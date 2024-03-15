using System.Globalization;

namespace PointOfSale
{
    internal class DBManeger
    {
        public static Product? FindProductById(int id, List<Product> products)
        {
            foreach (Product product in products)
            {
                if (product.Code == id)
                {
                    return product;
                }
            }
            return null;
        }

        public static List<Product> LoadProductsFromCSV(string fileName, List<Product> products, Stock currentStock)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()!) != null)
                {
                    string[] data = line.Split(',');
                    int code = int.Parse(data[0]);
                    string name = data[1];
                    double price = double.Parse(data[2], CultureInfo.InvariantCulture);
                    int stock = int.Parse(data[3]);
                    products.Add(new Product(code, name, price));
                    currentStock.stock.Add(code, stock);
                }
            }

            return products;
        }
    }
}
