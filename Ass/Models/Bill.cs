namespace  Ass.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserId { get; set; }
        public int status { get; set; }
        public virtual List<BillDetail> BillDetails{ get; set; }
        public virtual User User { get; set; }
    }
}
