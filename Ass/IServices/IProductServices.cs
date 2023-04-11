using Ass.Models;
using Ass.ViewModel;

namespace Ass.IServices
{
    public interface IProductServices
    {
        public bool CreateProduct(Product i);
        public bool UpdateProduct(Product i);
        public bool DeleteProduct(Guid id);
        public List<Product> GetAllProducts();
        public List<ProductView> GetAllProductsView();
        public ProductView GetProductsView(Guid id);
        public Product GetProductById(Guid id);
    }
}
