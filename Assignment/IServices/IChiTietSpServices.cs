using ClassLibrary1.Models;
namespace Assignment.IServices
{
    public interface IChiTietSpServices
    {
        public bool CreateChiTietSp(ChiTietSp p);
        public bool UpdateChiTietSp(ChiTietSp p);
        public bool DeleteChiTietSp(Guid id);
        public List<ChiTietSp> GetAllChiTietSps();
        public ChiTietSp GetChiTietSpById(Guid id);
        public List<ChiTietSp> GetChiTietSpByName(string name);
    }
}
