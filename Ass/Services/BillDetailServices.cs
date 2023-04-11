using Ass.IServices;
using Ass.Models;
using Ass.ViewModel;

namespace Ass.Services
{
    public class BillsDetailervices : IBillDetailServices
    {
        AssDBContext context;
        private ProductServices productServices;
        public BillsDetailervices()
        {
            context = new AssDBContext();
            productServices = new ProductServices();
        }

        public bool CreateBillDetail(BillDetail i)
        {
            try
            {
                context.BillsDetail.Add(i);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBillDetail(Guid id)
        {
            try
            {
                var bill = context.BillsDetail.FirstOrDefault(p => p.Id == id);
                if (bill != null)
                {
                    context.BillsDetail.Remove(bill);
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

        public List<BillDetail> GetAllBillDetails()
        {
            return context.BillsDetail.ToList();
        }
        public BillDetail GetBillDetailById(Guid id)
        {
            return context.BillsDetail.FirstOrDefault(c => c.Id == id);
        }

        public List<BillDetailView> GetBillDetailViewById(Guid id)
        {
            var lst = context.BillsDetail.Where(c => c.IdHD == id).ToList();
            List<BillDetailView> view = new List<BillDetailView>();
            foreach (var item in lst)
            {
                var a = productServices.GetProductsView(item.IdSP);
                BillDetailView viewItem = new BillDetailView()
                {
                    Id = item.Id,
                    IdHD = item.IdHD,
                    IdSp = item.IdSP,
                    Quantity = item.Quantity,
                    DuongDan = a.DuongDan,
                    Name = a.Name,
                    Price = a.GiaBan
                };
                view.Add(viewItem);
            }
            return view;
        }

        public bool UpdateBillDetail(BillDetail i)
        {
            try
            {
                var x = context.BillsDetail.FirstOrDefault(p => p.Id == i.Id);
                x.IdHD=i.IdHD;
                x.IdSP=i.IdSP;
                x.Price = i.Price;
                x.Quantity = i.Quantity;  
                context.BillsDetail.Update(x);
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
