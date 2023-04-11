using Ass.Models;

namespace Ass.IServices
{
    public interface IImageServices
    {
        public bool CreateImage(Image i);
        public bool UpdateImage(Image i);
        public bool DeleteImage(Guid id);
        public List<Image> GetAllImages();
        public Image GetImageById(Guid id);
    }
}
