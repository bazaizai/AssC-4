using Ass.IServices;
using Ass.Models;
using Ass.ViewModel;

namespace Ass.Services
{
    public class BillServices : IBillServices
    {
        AssDBContext context;

        public BillServices()
        {
            context = new AssDBContext();
        }

        public bool CreateBill(Bill i)
        {
            try
            {
                context.Bills.Add(i);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBill(Guid id)
        {
            try
            {
                var bill = context.Bills.FirstOrDefault(p => p.Id == id);
                if (bill != null)
                {
                    context.Bills.Remove(bill);
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

        public List<Bill> GetAllBills()
        {
            return context.Bills.ToList();
        }

        public List<BillView> GetAllBillViews()
        {
            var lst = (from bill in context.Bills 
                      join user in context.Users on bill.UserId equals user.Id 
                      select new BillView { 
                          Id = bill.Id,
                          UserId = bill.UserId,
                          UserName = user.Username,
                          status = bill.status,
                          CreateDate = bill.CreateDate
                      }).ToList();
            return lst;
        }

        public Bill GetBillById(Guid id)
        {
            return context.Bills.FirstOrDefault(c => c.Id == id);
        }

        public Bill GetBillViewById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBill(Bill i)
        {
            try
            {
                var x = context.Bills.FirstOrDefault(p => p.Id == i.Id);
                x.CreateDate = i.CreateDate;
                x.UserId = i.UserId;
                x.status = i.status;
                context.Bills.Update(x);
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
