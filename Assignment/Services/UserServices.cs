using Assignment.IServices;
using ClassLibrary1.Models;

namespace Assignment.Services
{
    public class UserServices: IUserServices
    {
        CuaHangGiayDBContext context;
        public UserServices()
        {
            context = new CuaHangGiayDBContext();
        }
        public bool CreateUser(User p)
        {
            try
            {
                context.Users.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                var User = context.Users.Find(id);
                context.Users.Remove(User);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }


        public User GetUserById(Guid id)
        {
            return context.Users.FirstOrDefault(p => p.Id == id);
        }
      
        public User GetUserBy(string usernameOrEmail, string password)
        {
            return context.Users.SingleOrDefault(p => (p.TaiKhoan == usernameOrEmail || p.Email == usernameOrEmail) && p.MatKhau == password);
        }

        public List<User> GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User p)
        {

            try
            {
                var User = context.Users.Find(p.Id);
                User.Ten = p.Ten;
                User.TrangThai = p.TrangThai;
                User.DiaChi = p.DiaChi;
                User.Roles = p.Roles;
                User.Email = p.Email;
                User.TaiKhoan= p.TaiKhoan;
                User.MatKhau= p.MatKhau;
                User.NgaySinh = p.NgaySinh;
                User.TrangThai= p.TrangThai;
                User.Sdt= p.Sdt;
                User.GioiTinh= p.GioiTinh;
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
