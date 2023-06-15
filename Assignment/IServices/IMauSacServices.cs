using ClassLibrary1.Models;
namespace Assignment.IServices
{
    public interface IMauSacServices
    {
        public bool CreateMauSac(MauSac p);
        public bool UpdateMauSac(MauSac p);
        public bool DeleteMauSac(Guid id);
        public List<MauSac> GetAllMauSacs();
        public MauSac GetMauSacById(Guid id);
        public List<MauSac> GetMauSacByName(string name);
    }
}
