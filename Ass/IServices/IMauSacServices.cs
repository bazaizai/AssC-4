using Ass.Models;

namespace Ass.IServices
{
    public interface IMauSacServices
    {
        public bool CreateMauSac(MauSac i);
        public bool UpdateMauSac(MauSac i);
        public bool DeleteMauSac(Guid id);
        public List<MauSac> GetAllMauSacs();
        public MauSac GetMauSacById(Guid id);
    }
}
