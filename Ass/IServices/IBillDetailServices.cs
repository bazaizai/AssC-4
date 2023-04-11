using Ass.Models;
using Ass.ViewModel;

namespace Ass.IServices
{
    public interface IBillDetailServices
    {
        public bool CreateBillDetail(BillDetail i);
        public bool UpdateBillDetail(BillDetail i);
        public bool DeleteBillDetail(Guid id);
        public List<BillDetail> GetAllBillDetails();
        public BillDetail GetBillDetailById(Guid id);
        public List<BillDetailView> GetBillDetailViewById(Guid id);
    }
}
