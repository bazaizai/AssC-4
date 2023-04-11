using Ass.Models;
using Ass.ViewModel;
using Newtonsoft.Json;

namespace Ass.Services
{
    public class SessionServices
    {
        public static List<Product> GetObjFromSession(ISession session, string key)
        {
            // Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return new List<Product>();
            // Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var products = JsonConvert.DeserializeObject<List<Product>>(jsonData);
            // Nếu null thì trả về 1 list rỗng
            return products;
        }
        public static List<CartView> GetObjFromCart(ISession session, string key)
        {
            // Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return new List<CartView>();
            // Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var cartdetail = JsonConvert.DeserializeObject<List<CartView>>(jsonData);
            // Nếu null thì trả về 1 list rỗng
            return cartdetail;
        }
        public static User GetObjFromUser(ISession session, string key)
        {
            // Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return null;
            // Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var user = JsonConvert.DeserializeObject<User>(jsonData);
            // Nếu null thì trả về 1 list rỗng
            return user;
        }
        public static void SetObjToSession(ISession session, string key, object values)
        {
            var jsonData = JsonConvert.SerializeObject(values);
            session.SetString(key, jsonData);
        }
        public static bool CheckObjInList(Guid id, List<Product> products)
        {
            return products.Any(x => x.Id == id);
        }
        public static bool CheckObjInListCart(Guid id, List<CartView> cartDetails)
        {
            return cartDetails.Any(x => x.Id == id);
        }
    }
}
