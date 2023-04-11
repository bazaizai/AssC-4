using Ass.Models;
using Ass.ViewModel;

namespace Ass.IServices
{
    public interface IBillServices
    {
         public bool CreateBill(Bill i);
        public bool UpdateBill(Bill i);
        public bool DeleteBill(Guid id);
        public List<Bill> GetAllBills();
        public List<BillView> GetAllBillViews();
        public Bill GetBillById(Guid id);
        public Bill GetBillViewById(Guid id);
    }
}
