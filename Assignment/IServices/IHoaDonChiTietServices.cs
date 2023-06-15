using ClassLibrary1.Models;
namespace Assignment.IServices
{
    public interface IHoaDonChiTietServices
    {
        public bool CreateHoaDonChiTiet(HoaDonChiTiet p);
        public bool UpdateHoaDonChiTiet(HoaDonChiTiet p);
        public bool DeleteHoaDonChiTiet(Guid id);
        public List<HoaDonChiTiet> GetAllHoaDonChiTiets();
        public HoaDonChiTiet GetHoaDonChiTietById(Guid id);
        public List<HoaDonChiTiet> GetHoaDonChiTietByName(string name);
    }
}
