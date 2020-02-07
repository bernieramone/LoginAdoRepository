using BusinessUsers;
using BusinessUsers.Model;

namespace UsersConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //UsersRepository usersRepository = new UsersRepository();
            UserBusiness business = new UserBusiness();


            User user = new User();

            user.Email = "EL_loco_bill@hotmaill.com";
            user.Nombre = "bill666";
            user.Password = "tool666s";
            user.status = 3;
            user.Usuario = "maynart James";

            var lstBuss = business.GetAllUsers();

            //var respuestaDelete = business.DeleteUser(1);
            //var updateRespuesta = business.UpdateUser(user);

            //var GetId = business.GetUserId(4);
            var insertRespuesta = business.InsertUser(user);


            //UserEntity userGet =  usersRepository.GetUserId(1);

            //var resultDelete = usersRepository.DeleteUser(6);
            //List<UserEntity> list = usersRepository.GetAllUsers();

            //bool succes = usersRepository.InsertUser(user);

            //bool updateSucces = usersRepository.UpdateUser(user);
        }
    }
}
    