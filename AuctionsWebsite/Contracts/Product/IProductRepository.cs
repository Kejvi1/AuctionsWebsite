using Entities.DAO.Product;

namespace Contracts.Product
{
    public interface IProductRepository
    {
        ProductDAO GetProduct(string name, string description);
    }
}