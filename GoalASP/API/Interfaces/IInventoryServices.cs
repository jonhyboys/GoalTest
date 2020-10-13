using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IInventoryServices
    {
        int AddProduct(IProduct product);
        Task<List<IProduct>> GetAllProducts();
        bool DeleteProduct(int id);
        void NotifyProductDeleted(IProduct id);
        void NotifyProductExpired(IProduct id);
    }
}
