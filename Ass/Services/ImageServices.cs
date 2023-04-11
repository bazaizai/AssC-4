using Ass.IServices;
using Ass.Models;

namespace Ass.Services
{
    public class ImageServices : IImageServices

    {
        public AssDBContext context;
        public ImageServices()
        {
            context = new AssDBContext();
        }

        public bool CreateImage(Image i)
        {
            try
            {
                context.Images.Add(i);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteImage(Guid id)
        {
            try
            {
                var i = context.Images.FirstOrDefault(p => p.Id == id);
                if (i != null)
                {
                    context.Images.Remove(i);
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

        public List<Image> GetAllImages()
        {
            return context.Images.ToList();
        }

        public Image GetImageById(Guid id)
        {
            return context.Images.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateImage(Image i)
        {

            try
            {
                var x = context.Images.FirstOrDefault(p => p.Id == i.Id);
                x.IdChiTietSp = i.IdChiTietSp;
                x.TrangThai = i.TrangThai;
                x.DuongDan = i.DuongDan;
                context.Images.Update(x);
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
