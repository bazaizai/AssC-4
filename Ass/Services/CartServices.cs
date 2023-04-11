using Ass.IServices;
using Ass.Models;

namespace Ass.Services
{
    public class CartServices : ICartServices
    {
        AssDBContext context;
        public CartServices()
        {
            context = new AssDBContext();
        }

        public bool CreateCart(Cart i)
        {
            try
            {
                context.Carts.Add(i);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCart(Guid id)
        {
             try
            {
                var bill = context.Carts.FirstOrDefault(p => p.UserID == id);
                if (bill != null)
                {
                    context.Carts.Remove(bill);
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

        public List<Cart> GetAllCarts()
        {
            return context.Carts.ToList();
        }

        public Cart GetCartById(Guid id)
        {
            return context.Carts.FirstOrDefault(c => c.UserID == id);
        }

        public bool UpdateCart(Cart i)
        {
            try
            {
                var x = context.Carts.FirstOrDefault(p => p.UserID == i.UserID);
                x.Description = x.Description;
                context.Carts.Update(x);
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
