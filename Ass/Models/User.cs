namespace Ass.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid RoleID { get; set; }
        public int Status { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Role Roles { get; set; }
        public virtual List<Bill> Bills { get; set; }
    }
}
