namespace Ass.ViewModel
{
    public class BillView
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        
        public int status { get; set; }
    }
}
