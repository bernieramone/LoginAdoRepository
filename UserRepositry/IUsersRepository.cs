using System.Collections.Generic;
using UserRepositry.Entities;

namespace UserRepositry
{
    public interface IUsersRepository
    {
        List<UserEntity> GetAllUsers();
        UserEntity GetUserId(int id);
        bool DeleteUser(int id);
        bool InsertUser(UserEntity user);
        bool UpdateUser(UserEntity user);


    }
}
