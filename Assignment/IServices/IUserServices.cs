using ClassLibrary1.Models;
using Polly;

namespace Assignment.IServices
{
    public interface IUserServices
    {
        public bool CreateUser(User p);
        public bool UpdateUser(User p);
        public bool DeleteUser(Guid id);
        public List<User> GetAllUsers();
        public User GetUserById(Guid id);
        public List<User> GetUserByName(string name);
        public User GetUserBy(string usernameOrEmail, string password);
        
       
    }
}
