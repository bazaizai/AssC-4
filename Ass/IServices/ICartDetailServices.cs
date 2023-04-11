using Ass.Models;
using Ass.ViewModel;

namespace Ass.IServices
{
    public interface ICartDetailServices
    {
        public bool CreateCartDetail(CartDetail i);
        public bool UpdateCartDetail(CartDetail i);
        public bool DeleteCartDetail(Guid id);
        public List<CartDetail> GetAllCartDetails();
        public List<CartDetail> GetCartDetailById(Guid id);
        public List<CartDetailView> GetCartDetailViewById(Guid id);
    }
}
