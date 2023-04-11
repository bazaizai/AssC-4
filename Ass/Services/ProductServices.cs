using Ass.IServices;
using Ass.Models;
using Ass.ViewModel;

namespace Ass.Services
{
    public class ProductServices : IProductServices
    {
        AssDBContext context;

        public ProductServices()
        {
            context = new AssDBContext();
        }

        public bool CreateProduct(Product i)
        {
            try
            {
                context.Products.Add(i);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {

            try
            {
                var product = context.Products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    context.Products.Remove(product);
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

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public List<ProductView> GetAllProductsView()
        {
            var list = (from a in context.Products.ToList()
                        join b in context.ChatLieus.ToList() on a.IdChatLieu equals b.Id
                        join c in context.MauSacs.ToList() on a.IdMauSac equals c.Id
                        join d in context.Teams.ToList() on a.IdTeam equals d.Id
                        select new ProductView
                        {
                            Id = a.Id,
                            TeanCatLieu = b.Ten,
                            Name = a.Name,
                            TenMau = c.Ten,
                            TenTeam = d.Ten,
                            TrangThai = a.TrangThai,
                            SoLuongTon = a.SoLuongTon,
                            GiaBan = a.GiaBan,
                            MoTa = a.MoTa,
                            IdChatLieu = a.IdChatLieu,
                            IdMauSac = a.IdMauSac,
                            IdTeam = a.IdTeam

                        }).ToList();
            foreach (var item in list)
            {
                var lst = (context.Images.Where(c => c.IdChiTietSp == item.Id).ToList());
                if (lst.Count() > 0)
                {
                    foreach (var i in lst)
                    {
                        item.DuongDan.Add(i.DuongDan);
                    }
                }

            }
            return list;
        }
        public ProductView GetProductsView(Guid id)
        {
            var pr = GetAllProductsView().FirstOrDefault(c => c.Id == id);
            return pr;
        }

        public Product GetProductById(Guid id)
        {
            return context.Products.FirstOrDefault(c => c.Id == id);
        }

        public ProductView GetProductByIdView(Guid id)
        {
            var a = GetAllProductsView().FirstOrDefault(c => c.Id == id);
            return a;
        }
        public bool UpdateProduct(Product i)
        {

            try
            {
                var x = context.Products.FirstOrDefault(p => p.Id == i.Id);
                    x.IdMauSac = i.IdMauSac;
                    x.Name = i.Name;
                    x.MoTa = i.MoTa;
                    x.IdChatLieu = i.IdChatLieu;
                    x.IdTeam = i.IdTeam;
                    x.GiaBan = i.GiaBan;
                    x.TrangThai = i.TrangThai;
                    x.SoLuongTon = i.SoLuongTon;
                    context.Products.Update(x);
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
