namespace Ass.ViewModel
{
    public class BillDetailView
    {
        public Guid Id { get; set; }
        public Guid IdHD { get; set; }
        public Guid IdSp { get; set; }
        public List<string> DuongDan { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
