

namespace Mud.Data
{
    public interface IStorage
    {
        public Task<Boolean> ClearStorage();
        public Task<Int32> AddProduct(IProduct product);
        public Task<IProduct?> GetProductById(int id);
        public Task<List<IProduct>> GetAllProducts();
        public Task<Int32> UpdateProduct(IProduct product);
        public Task<Int32> DeleteProduct(Int32 Id);
    }
}
