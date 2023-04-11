using Ass.Models;

namespace Ass.IServices
{
    public interface IChatLieuServices
    {
        public bool CreateChatLieu(ChatLieu i);
        public bool UpdateChatLieu(ChatLieu i);
        public bool DeleteChatLieu(Guid id);
        public List<ChatLieu> GetAllChatLieus();
        public ChatLieu GetChatLieuById(Guid id);
    }
}
