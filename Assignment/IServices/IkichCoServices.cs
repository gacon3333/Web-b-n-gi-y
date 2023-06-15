using ClassLibrary1.Models;

namespace Assignment.IServices
{
    public interface IkichCoServices
    {
 
            public bool CreateKichCo(KichCo p);
            public bool UpdateKichCo(KichCo p);
            public bool DeleteKichCo(Guid id);
            public List<KichCo> GetAllKichCos();
            public KichCo GetKichCoById(Guid id);
            public List<KichCo> GetKichCoByName(string name);
   

}
}
