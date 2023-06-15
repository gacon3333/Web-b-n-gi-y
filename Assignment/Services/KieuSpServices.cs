using Assignment.IServices;
using ClassLibrary1.Models;

namespace Assignment.Services
{
    public class KieuSpServices:IKieuSpServices
    {
        CuaHangGiayDBContext context;
        public KieuSpServices()
        {
            context = new CuaHangGiayDBContext();
        }
        public bool CreateKieuSp(KieuSp p)
        {
            try
            {
                context.KieuSps.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteKieuSp(Guid id)
        {
            try
            {
                var KieuSp = context.KieuSps.Find(id);
                context.KieuSps.Remove(KieuSp);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<KieuSp> GetAllKieuSps()
        {
            return context.KieuSps.ToList();
        }


        public KieuSp GetKieuSpById(Guid id)
        {
            return context.KieuSps.FirstOrDefault(p => p.Id == id);
        }

        public List<KieuSp> GetKieuSpByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateKieuSp(KieuSp p)
        {

            try
            {
                var KieuSp = context.KieuSps.Find(p.Id);
                KieuSp.Ten = p.Ten;
                KieuSp.TrangThai = p.TrangThai;
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
