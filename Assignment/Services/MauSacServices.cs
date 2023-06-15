using Assignment.IServices;
using ClassLibrary1.Models;

namespace Assignment.Services
{
    public class MauSacServices:IMauSacServices
    {
        CuaHangGiayDBContext context;
        public MauSacServices()
        {
            context = new CuaHangGiayDBContext();
        }
        public bool CreateMauSac(MauSac p)
        {
            try
            {
                context.MauSacs.Add(p);
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
                var MauSac = context.MauSacs.Find(id);
                context.MauSacs.Remove(MauSac);
                context.SaveChanges();
                return true;
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
            return context.MauSacs.FirstOrDefault(p => p.Id == id);
        }

        public List<MauSac> GetMauSacByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMauSac(MauSac p)
        {

            try
            {
                var MauSac = context.MauSacs.Find(p.Id);
                MauSac.Ten = p.Ten;
                MauSac.TrangThai = p.TrangThai;
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
