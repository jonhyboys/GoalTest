using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IProductService
    {
        int AddProduct(IProductExpiration product);
        Task<List<IProduct>> GetAllProducts();
        int DeleteProduct(int id);
        void NotifyProductDeleted();
        void NotifyProductExpired();
    }
}
