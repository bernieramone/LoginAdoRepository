using BusinessUsers.Model;
using System.Collections.Generic;

namespace BusinessUsers
{
    public interface IUserBusiness
    {
        List<User> GetAllUsers();
        User GetUserId(int id);
        bool DeleteUser(int id);
        bool InsertUser(User user);
        bool UpdateUser(User user);
    }
}
