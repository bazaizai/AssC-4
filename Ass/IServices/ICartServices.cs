using Ass.Models;

namespace Ass.IServices
{
    public interface ICartServices
    {
        public bool CreateCart(Cart i);
        public bool UpdateCart(Cart i);
        public bool DeleteCart(Guid id);
        public List<Cart> GetAllCarts();
        public Cart GetCartById(Guid id);
    }
}
