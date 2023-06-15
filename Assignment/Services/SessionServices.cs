using ClassLibrary1.Models;
using Newtonsoft.Json;

namespace Assignment.Services
{
    public static class SessionServices
    {
        public static List<ChiTietSp> GetObjFromSession(ISession session, string key )
        {
            //// Lấy string json từ session 
            //var jsondata=session.GetString(key);
            ////chuyển đổi dữ liệu vừa lấy đc sang dạng mong muốn
            //var pro = JsonConvert.DeserializeObject<List<ChiTietSp>>(jsondata);
            //if (pro == null)
            //{
            //    return new List<ChiTietSp>();// nếu null thì trả về 1 list rỗng              
            //}
            //else return pro;

            // Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return new List<ChiTietSp>();
            // Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var products = JsonConvert.DeserializeObject<List<ChiTietSp>>(jsonData);
            // Nếu null thì trả về 1 list rỗng
            return products;
        }
        public static void SetObjToSession(ISession session, string key, object values)
        {
            var jsondata = JsonConvert.SerializeObject(values);
            session.SetString(key, jsondata);
        }
        public static bool CheckObjInList(Guid id , List<ChiTietSp> chiTietSps)
        {
            return chiTietSps.Any(s => s.Id == id);
        }
    }
}
