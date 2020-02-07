using BusinessUsers.Model;
using UserRepositry.Entities;

namespace BusinessUsers
{
    public static class Mapper
    {
        public static User GetUserBusiness(UserEntity userEntity)
        {
            User userBus = new User
            {
                Email = userEntity.Email,
                ID = userEntity.ID,
                Nombre = userEntity.Nombre,
                Password = userEntity.Password,
                status = userEntity.status,
                Usuario = userEntity.Usuario,
                securityKey = userEntity.securityKey
                
            };

            return userBus;
        }

        public static UserEntity GetUserEntity(User user)
        {
            UserEntity userEntity = new UserEntity
            {
                Usuario = user.Usuario,
                status = user.status,
                Email = user.Email,
                ID = user.ID,
                Nombre = user.Nombre,
                Password = user.Password,
                securityKey = user.securityKey
            };

            return userEntity;
                
        }
    }
}
