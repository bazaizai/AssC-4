using Ass.IServices;
using Ass.Models;

namespace Ass.Services
{
    public class UserServices : IUserServices
    {
        AssDBContext context;
        public UserServices()
        {
            context = new AssDBContext();
        }

        public bool CreateUser(User i)
        {
            try
            {
                i.Id = Guid.NewGuid();
                i.Status = 0;
                var a = context.Roles.FirstOrDefault(c => c.Id == Guid.Parse("a1cb2b81-b592-44a6-b8ed-297a6036ba2b"));
                var b = context.Roles.FirstOrDefault(c => c.RoleName == "QuanLy");
                if (a != null)
                {
                    i.RoleID = a.Id;
                }
                else
                {
                    Role role = new Role()
                    {
                        Id = Guid.Parse("a1cb2b81-b592-44a6-b8ed-297a6036ba2b"),
                        RoleName = "KhachHang",
                        Description = "cay",
                        Status = 0

                    };
                    context.Roles.Add(role);
                    context.SaveChanges();
                    i.RoleID = role.Id;
                }
                if (b == null)
                {
                    Role role = new Role()
                    {
                        Id = Guid.NewGuid(),
                        RoleName = "QuanLy",
                        Description = "cay",
                        Status = 0

                    };
                    context.Roles.Add(role);
                    context.SaveChanges();
                }
                if (context.Users.FirstOrDefault(c => c.Username == i.Username) == null)
                {
                    context.Users.Add(i);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                var bill = context.Users.FirstOrDefault(p => p.Id == id);
                if (bill != null)
                {
                    context.Users.Remove(bill);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserByTKMK(string name, string pass)
        {
            return context.Users.FirstOrDefault(c => c.Username == name && c.Password == pass);
        }

        public bool UpdateUser(User i)
        {
            try
            {
                var x = context.Users.FirstOrDefault(p => p.Id == i.Id);
                x.Username = i.Username;
                x.Password = i.Password;
                x.Roles = i.Roles;
                x.Status = i.Status;
                context.Users.Update(x);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
