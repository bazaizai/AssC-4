using Ass.Models;

namespace Ass.IServices
{
    public interface IRoleServices
    {
        public bool CreateRole(Role i);
        public bool UpdateRole(Role i);
        public bool DeleteRole(Guid id);
        public List<Role> GetAllRoles();
        public Role GetRoleById(Guid id);
    }
}
