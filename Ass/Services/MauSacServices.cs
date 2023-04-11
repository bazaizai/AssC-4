using Ass.IServices;
using Ass.Models;

namespace Ass.Services
{
    public class MauSacServices : IMauSacServices
    {
        AssDBContext context;

        public MauSacServices()
        {
            context = new AssDBContext();
        }

        public bool CreateMauSac(MauSac i)
        {
            try
            {
                context.MauSacs.Add(i);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteMauSac(Guid id)
        {
            try
            {
                var product = context.MauSacs.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    context.MauSacs.Remove(product);
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

        public List<MauSac> GetAllMauSacs()
        {
            return context.MauSacs.ToList();
        }

        public MauSac GetMauSacById(Guid id)
        {
            return context.MauSacs.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateMauSac(MauSac i)
        {
            try
            {
                var x = context.MauSacs.FirstOrDefault(p => p.Id == i.Id);
                x.Ten = i.Ten;
                x.TrangThai = i.TrangThai;
                context.MauSacs.Update(x);
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
