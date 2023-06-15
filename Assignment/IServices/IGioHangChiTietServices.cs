using ClassLibrary1.Models;
namespace Assignment.IServices
{
    public interface IGioHangChiTietServices
    {
        public bool CreateGioHangChiTiet(/*Guid userId, Guid productId*/GioHangChiTiet p);
        public bool AddProductToCart(Guid userId, Guid productId, int quantity);
        public bool UpdateGioHangChiTiet(GioHangChiTiet p);
        public bool DeleteGioHangChiTiet(Guid id);
        public List<GioHangChiTiet> GetAllGioHangChiTiets();
        public GioHangChiTiet GetGioHangChiTietById(Guid id);
        //public List<GioHangChiTiet> GetGioHangChiTietByName(string name);
    }
}
