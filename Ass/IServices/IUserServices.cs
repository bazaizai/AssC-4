using Ass.Models;

namespace Ass.IServices
{
    public interface IUserServices
    {
        public bool CreateUser(User i);
        public bool UpdateUser(User i);
        public bool DeleteUser(Guid id);
        public List<User> GetAllUsers();
        public User GetUserByTKMK(string name, string pass);
    }
}
