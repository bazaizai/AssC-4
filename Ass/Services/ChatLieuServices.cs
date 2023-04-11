using Ass.IServices;
using Ass.Models;

namespace Ass.Services
{
    public class ChatLieuServices:IChatLieuServices
    {
        AssDBContext dbContext;
        public ChatLieuServices()
        {
            dbContext = new AssDBContext();
        }

        public bool CreateChatLieu(ChatLieu i)
        {
            try
            {
                dbContext.ChatLieus.Add(i);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteChatLieu(Guid id)
        {
            try
            {
                var product = dbContext.ChatLieus.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    dbContext.ChatLieus.Remove(product);
                    dbContext.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<ChatLieu> GetAllChatLieus()
        {
            return dbContext.ChatLieus.ToList();
        }

        public ChatLieu GetChatLieuById(Guid id)
        {
            return dbContext.ChatLieus.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateChatLieu(ChatLieu i)
        {
            try
            {
                var x = dbContext.ChatLieus.FirstOrDefault(p => p.Id == i.Id);
                x.Ten = i.Ten;
                x.TrangThai = i.TrangThai;
                dbContext.ChatLieus.Update(x);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
