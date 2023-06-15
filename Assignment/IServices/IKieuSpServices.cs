using ClassLibrary1.Models;
namespace Assignment.IServices
{
    public interface IKieuSpServices
    {
        public bool CreateKieuSp(KieuSp p);
        public bool UpdateKieuSp(KieuSp p);
        public bool DeleteKieuSp(Guid id);
        public List<KieuSp> GetAllKieuSps();
        public KieuSp GetKieuSpById(Guid id);
        public List<KieuSp> GetKieuSpByName(string name);
    }
}
