

namespace Ass.Models
{
    public  class Image
    {
        public Guid Id { get; set; }
        public Guid IdChiTietSp { get; set; }
        public string DuongDan { get; set; }
        public int TrangThai { get; set; }
        public virtual Product Product { get; set; }
    }
}
