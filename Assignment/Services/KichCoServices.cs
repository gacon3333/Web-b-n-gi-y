using Assignment.IServices;
using ClassLibrary1.Models;

namespace Assignment.Services
{
    public class KichCoServices:IkichCoServices
    {
        CuaHangGiayDBContext context;
        public KichCoServices()
        {
            context = new CuaHangGiayDBContext();
        }
        public bool CreateKichCo(KichCo p)
        {
            try
            {
                context.KichCos.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteKichCo(Guid id)
        {
            try
            {
                var KichCo = context.KichCos.Find(id);
                context.KichCos.Remove(KichCo);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<KichCo> GetAllKichCos()
        {
            return context.KichCos.ToList();
        }


        public KichCo GetKichCoById(Guid id)
        {
            return context.KichCos.FirstOrDefault(p => p.Id == id);
        }

        public List<KichCo> GetKichCoByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateKichCo(KichCo p)
        {

            try
            {
                var KichCo = context.KichCos.Find(p.Id);
                KichCo.Size = p.Size;
                KichCo.TrangThai = p.TrangThai;
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
