namespace  Ass.Models
{
    public  class MauSac
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public int TrangThai { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
