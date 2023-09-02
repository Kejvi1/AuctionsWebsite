using Contracts.Product;
using Entities.DAO.Product;
using System.Linq;

namespace Repositories.Product
{
    public class ProductRepository : GenericRepository<ProductDAO>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public ProductDAO GetProduct(string name, string description)
        {
            return base.Find(p => p.ProductName == name && p.ProductDescription == description).FirstOrDefault();
        }
    }
}