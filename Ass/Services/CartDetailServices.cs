using Ass.IServices;
using Ass.Models;
using Ass.ViewModel;

namespace Ass.Services
{
    public class CartsDetailservices : ICartDetailServices
    {
        AssDBContext context;
        IProductServices productServices;
        public CartsDetailservices()
        {
            context = new AssDBContext();
            productServices = new ProductServices();
        }

        public bool CreateCartDetail(CartDetail i)
        {
            try
            {
                if(context.Carts.FirstOrDefault(c=>c.UserID == i.UserID)  == null)
                {
                    Cart cart = new Cart()
                    {
                        UserID = i.UserID,
                        Description = "Khong",
                       
                    };
                    context.Carts.Add(cart);
                    context.SaveChanges();
                }
                context.CartsDetails.Add(i);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCartDetail(Guid id)
        {
            try
            {
                var bill = context.CartsDetails.FirstOrDefault(p => p.Id == id);
                if (bill != null)
                {
                    context.CartsDetails.Remove(bill);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CartDetail> GetAllCartDetails()
        {
            return context.CartsDetails.ToList();
        }

        public List<CartDetail> GetCartDetailById(Guid id)
        {
            return context.CartsDetails.Where(c => c.UserID == id).ToList();
        }

        public List<CartDetailView> GetCartDetailViewById(Guid id)
        {
            var lst = context.CartsDetails.Where(c => c.UserID == id).ToList();
            List<CartDetailView> view = new List<CartDetailView>();
            foreach (var item in lst)
            {
                var a = productServices.GetProductsView(item.IDSP);
                CartDetailView viewItem = new CartDetailView()
                {
                    Id = item.Id,
                    UserId = item.UserID,
                    IdSp = item.IDSP,
                    Quantity = item.Quantity,
                    DuongDan = a.DuongDan,
                    Name =a.Name,
                    Price = a.GiaBan
                };
                view.Add(viewItem);
            }
            return view;
        }

        public bool UpdateCartDetail(CartDetail i)
        {
            try
            {
                var x = context.CartsDetails.FirstOrDefault(p => p.Id == i.Id);
                x.UserID = i.UserID;
                x.IDSP = i.IDSP;
                x.Quantity = i.Quantity;
                context.CartsDetails.Update(x);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
