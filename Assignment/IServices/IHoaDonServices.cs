using ClassLibrary1.Models;
namespace Assignment.IServices
{
    public interface IHoaDonServices
    {
        public bool CreateHoaDon(HoaDon p);
        public bool UpdateHoaDon(HoaDon p);
        public bool DeleteHoaDon(Guid id);
        public List<HoaDon> GetAllHoaDons();
        public HoaDon GetHoaDonById(Guid id);
        public List<HoaDon> GetHoaDonByName(string name);
    }
}
