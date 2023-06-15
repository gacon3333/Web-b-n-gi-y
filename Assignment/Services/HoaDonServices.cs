using Assignment.IServices;
using ClassLibrary1.Models;

namespace Assignment.Services
{
    public class HoaDonServices: IHoaDonServices
    {
        CuaHangGiayDBContext context;
        public HoaDonServices()
        {
            context = new CuaHangGiayDBContext();
        }
        public bool CreateHoaDon(HoaDon p)
        {
            try
            {
                context.HoaDons.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteHoaDon(Guid id)
        {
            try
            {
                var HoaDon = context.HoaDons.Find(id);
                context.HoaDons.Remove(HoaDon);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<HoaDon> GetAllHoaDons()
        {
            return context.HoaDons.ToList();
        }


        public HoaDon GetHoaDonById(Guid id)
        {
            return context.HoaDons.FirstOrDefault(p => p.Id == id);
        }

        public List<HoaDon> GetHoaDonByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHoaDon(HoaDon p)
        {
            try
            {
                var HoaDon = context.HoaDons.Find(p.Id);
                HoaDon.TrangThai = p.TrangThai;
                HoaDon.NgayTao= DateTime.Now;
                HoaDon.MoTa = p.MoTa;
                HoaDon.TrangThai = p.TrangThai;
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
