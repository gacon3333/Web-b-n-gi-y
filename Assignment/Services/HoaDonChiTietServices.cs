using Assignment.IServices;
using ClassLibrary1.Models;

namespace Assignment.Services
{
    public class HoaDonChiTietServices: IHoaDonChiTietServices
    {
        CuaHangGiayDBContext context;
        public HoaDonChiTietServices()
        {
            context = new CuaHangGiayDBContext();
        }
        public bool CreateHoaDonChiTiet(HoaDonChiTiet p)
        {
            try
            {
                context.HoaDonChiTiets.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteHoaDonChiTiet(Guid id)
        {
            try
            {
                var HoaDonChiTiet = context.HoaDonChiTiets.Find(id);
                context.HoaDonChiTiets.Remove(HoaDonChiTiet);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<HoaDonChiTiet> GetAllHoaDonChiTiets()
        {
            return context.HoaDonChiTiets.ToList();
        }


        public HoaDonChiTiet GetHoaDonChiTietById(Guid id)
        {
            return context.HoaDonChiTiets.FirstOrDefault(p => p.Id == id);
        }

        public List<HoaDonChiTiet> GetHoaDonChiTietByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHoaDonChiTiet(HoaDonChiTiet p)
        {
            try
            {
                var HoaDonChiTiet = context.HoaDonChiTiets.Find(p.Id);
                HoaDonChiTiet.IdHoaDon = p.IdHoaDon;
                HoaDonChiTiet.DonGia = p.DonGia;
                HoaDonChiTiet.TrangThai = p.TrangThai;
                HoaDonChiTiet.IdChiTietSp=p.IdChiTietSp;
                HoaDonChiTiet.SoLuong = p.SoLuong;
                HoaDonChiTiet.DiaChi= p.DiaChi;
                HoaDonChiTiet.Ten= p.Ten;
                HoaDonChiTiet.Sdt= p.Sdt;
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
