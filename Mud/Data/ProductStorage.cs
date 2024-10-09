using System.Diagnostics;

namespace Mud.Data
{
    public class ProductStorage : IStorage
    {
        private readonly SQLiteContext _context;
        public ProductStorage(SQLiteContext context)
        {
            Debug.WriteLine("ProductStorage constructor called");
            _context = context;
        }

        public Task<Boolean> ClearStorage()
        {
            Boolean result = false;
            Boolean result2 = false;
            result = _context.Database.EnsureDeleted();
            result2 = _context.Database.EnsureCreated();
            return Task.FromResult(result && result2);
        }
        public Task<Int32> AddProduct(IProduct product)
        {
            var result = _context.Products.Add((Product)product);
            var result2 = _context.SaveChanges();
            Debug.WriteLine($"AddProduct: {product.Id} / {result2}");
            return Task.FromResult(result2);
        }
        public Task<IProduct?> GetProductById(int id)
        {
            IProduct? result = _context.Products.Find(id);
            return Task.FromResult<IProduct?>(result);
        }
        public Task<List<IProduct>> GetAllProducts()
        {
            List<IProduct> result = _context.Products.ToList<IProduct>();
            return Task.FromResult(result);
        }
        public Task<Int32> UpdateProduct(IProduct product)
        {
            var result = _context.Products.Update((Product)product);
            var result2 = _context.SaveChanges();
            return Task.FromResult(result2);
        }
        public Task<Int32> DeleteProduct(Int32 Id)
        {
            Int32 results = -1;
            var product = _context.Products.Find(Id);
            if (product != null)
            {
                _context.Products.Remove(product);
                results = _context.SaveChanges();
            }
            return Task.FromResult(results);
        }
    }
}
