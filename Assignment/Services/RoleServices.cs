using Assignment.IServices;
using ClassLibrary1.Models;

namespace Assignment.Services
{
    public class RoleServices:IRoleServices
    {
        CuaHangGiayDBContext context;
        public RoleServices()
        {
            context = new CuaHangGiayDBContext();
        }
        public bool CreateRole(Role p)
        {
            try
            {
                context.Roles.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRole(Guid id)
        {
            try
            {
                var Role = context.Roles.Find(id);
                context.Roles.Remove(Role);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Role> GetAllRoles()
        {
            return context.Roles.ToList();
        }


        public Role GetRoleById(Guid id)
        {
            return context.Roles.FirstOrDefault(p => p.Id == id);
        }

        public List<Role> GetRoleByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRole(Role p)
        {

            try
            {
                var Role = context.Roles.Find(p.Id);
                Role.Ten = p.Ten;
                Role.TrangThai = p.TrangThai;
                Role.MoTa= p.MoTa;
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
