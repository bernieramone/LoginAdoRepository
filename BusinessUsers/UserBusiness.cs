using BusinessUsers.Model;
using System;
using System.Collections.Generic;
using UserRepositry;
using UsuariosHelper;

namespace BusinessUsers
{
    public class UserBusiness : IUserBusiness
    {

        UsersRepository context;

        public UserBusiness()
        {
            context = new UsersRepository();
        }
        public List<User> GetAllUsers()
        {
            try
            {
                var lstUsers = context.GetAllUsers();

                if (lstUsers == null || lstUsers.Count < 0)
                {
                    throw new Exception("Lista vacia");
                }

                List<User> lstBusUser = new List<User>();

                foreach (var userEntity in lstUsers)
                {
                    User userBus = Mapper.GetUserBusiness(userEntity);
                    userBus.Password = SecurityHelper.Decrypt(userBus.Password, userBus.securityKey);
                    lstBusUser.Add(userBus);

                }

                return lstBusUser;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
        public User GetUserId(int id)
        {
            try
            {
                var userEntity = context.GetUserId(id);

                userEntity.Password = SecurityHelper.Decrypt(userEntity.Password, userEntity.securityKey);

                if (userEntity == null)
                {
                    throw new Exception("No existe el usuario");
                }

                return Mapper.GetUserBusiness(userEntity);



            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteUser(int id)
        {
            try
            {
                var result = context.DeleteUser(id);

                if (!result)
                {
                    throw new Exception("Error al Eliminar usuario");
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertUser(User user)
        {
            try
            {
                var userEntity = Mapper.GetUserEntity(user);
                
                userEntity.securityKey = SecurityHelper.GenerateEncryptionKey();
                userEntity.Password = SecurityHelper.Encrypt(userEntity.Password, userEntity.securityKey);

                var result = context.InsertUser(userEntity);

                if (!result)
                {

                    throw new Exception("Error al insertat usuario");

                }

                return result;


                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var userEntity = Mapper.GetUserEntity(user);
                var result = context.UpdateUser(userEntity);

                if (!result)
                {

                    throw new Exception("Error al Actualizar usuario");

                }

                return result;



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
