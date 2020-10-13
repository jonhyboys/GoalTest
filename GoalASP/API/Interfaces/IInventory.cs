using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IInventory
    {
        int AddProduct(IProduct product);
        Task<List<IProduct>> GetAllProducts();
        bool DeleteProduct(int id);
        bool NotifyProductDeleted(IProduct id);
        bool NotifyProductExpired(IProduct id);
    }
}
