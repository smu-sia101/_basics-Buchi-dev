using MonolithApp.Demo.Models;
using SQLite;

namespace MonolithApp.Demo.Services
{
    public class ProductsService
    {
        private string dbPath =>
            Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments),
            "Products.db");
        private readonly ISQLiteConnection db;

        public ProductsService()
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Product>();
        }

        public void AddProduct(Product product)
        {
            db.Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            db.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            db.Delete(product);
        }

        public Product GetProductById(int id)
        {
            return db.Table<Product>().FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetAllProducts()
        {
            return db.Table<Product>().ToList();
        }
    }
}
