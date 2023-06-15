using Assignment.IServices;
using ClassLibrary1.Models;

namespace Assignment.Services
{
    public class GioHangServices:IGioHangServices
    {
        CuaHangGiayDBContext context;
        public GioHangServices()
        {
            context = new CuaHangGiayDBContext();
        }
        public bool CreateGioHang(GioHang p)
        {         
            try
            {
                context.GioHangs.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteGioHang(Guid id)
        {
            try
            {
                var GioHang = context.GioHangs.Find(id);
                context.GioHangs.Remove(GioHang);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GioHang> GetAllGioHangs()
        {
            return context.GioHangs.ToList();
        }


        public GioHang GetGioHangById(Guid id)
        {
            return context.GioHangs.FirstOrDefault(p => p.UserId == id);
        }

        public List<GioHang> GetGioHangByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGioHang(GioHang p)
        {
            try
            {
                var GioHang = context.GioHangs.Find(p.UserId);
                GioHang.TrangThai = p.TrangThai;
                GioHang.MoTa = p.MoTa;
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
