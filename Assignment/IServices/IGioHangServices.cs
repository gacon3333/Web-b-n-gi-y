using ClassLibrary1.Models;
namespace Assignment.IServices
{
    public interface IGioHangServices
    {
        public bool CreateGioHang(GioHang p);
        public bool UpdateGioHang(GioHang p);
        public bool DeleteGioHang(Guid id);
        public List<GioHang> GetAllGioHangs();
        public GioHang GetGioHangById(Guid id);
        public List<GioHang> GetGioHangByName(string name);
    }
}
