using Ass.Models;

namespace Ass.ViewModel
{
    public class ProductView
    {
        public Guid Id { get; set; }
        public Guid IdMauSac { get; set; }
        public string Name { get; set; }
        public string TenMau { get; set; }
        public string TenTeam { get; set; }
        public string TeanCatLieu { get; set; }
        public Guid IdTeam { get; set; }
        public Guid IdChatLieu { get; set; }
        public string MoTa { get; set; }
        public List<string> DuongDan =new List<string>();
        public int SoLuongTon { get; set; }
        public int GiaBan { get; set; }
        public int TrangThai { get; set; }
    }
}
