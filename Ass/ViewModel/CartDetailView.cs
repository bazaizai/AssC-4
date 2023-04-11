namespace Ass.ViewModel
{
    public class CartDetailView
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid IdSp { get; set; }
        public List<string> DuongDan { get; set; } 
        public string Name { get; set;}
        public int Price { get; set;}
        public int Quantity { get; set;}

    }
}
