using Ass.IServices;
using Ass.Models;

namespace Ass.Services
{
    public class RoleServices : IRoleServices
    {
        AssDBContext context;
        public RoleServices()
        {
            context = new AssDBContext();
        }

        public bool CreateRole(Role i)
        {
            try
            {
                context.Roles.Add(i);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRole(Guid id)
        {
            try
            {
                var bill = context.Roles.FirstOrDefault(p => p.Id == id);
                if (bill != null)
                {
                    context.Roles.Remove(bill);
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

        public List<Role> GetAllRoles()
        {
            return context.Roles.ToList();
        }

        public Role GetRoleById(Guid id)
        {
            return context.Roles.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateRole(Role i)
        {
            try
            {
                var x = context.Roles.FirstOrDefault(p => p.Id == i.Id);
                x.RoleName = i.RoleName;
                x.Description = i.Description;
                x.Status = i.Status;
                context.Roles.Update(x);
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
