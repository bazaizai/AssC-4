
namespace Ass.Models
{
 
    public  class Product
    {
        public Guid Id { get; set; }
        public Guid IdMauSac { get; set; }
        public Guid IdTeam { get; set; }
        public Guid IdChatLieu { get; set; }
        public string Name { get; set; }
        public string MoTa { get; set; }
        public int SoLuongTon { get; set; }
        public int GiaBan { get; set; }
        public int TrangThai { get; set; }
        public virtual List<BillDetail> BillDetails { get; set; }
        public virtual List<CartDetail> CartDetails { get; set; }
        public virtual List<Image> Images { get; set; }
        public virtual MauSac MauSac { get; set; }
        public virtual Team Team { get; set; }
        public virtual ChatLieu ChatLieu { get; set; }
        
    }
}
