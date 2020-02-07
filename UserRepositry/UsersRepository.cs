using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UserRepositry.Entities;

namespace UserRepositry
{
    public class UsersRepository : IUsersRepository
    {
        private readonly string connString = ConfigurationManager.ConnectionStrings["UserLogInConn"].ConnectionString;


        public bool DeleteUser(int id)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("DeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", id);
                    var result = cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    throw new Exception("Error al borrar usuario\n" + ex.Message);
                }

                return true;
            }
        }

        public List<UserEntity> GetAllUsers()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<UserEntity> lstUsers = new List<UserEntity>();

                try
                {
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    


                    while (rdr.Read())
                    {
                        UserEntity userEntity = new UserEntity();
                        userEntity.ID = Convert.ToInt32(rdr["ID"]);
                        userEntity.Email = rdr["email"].ToString();
                        userEntity.Nombre = rdr["Nombre"].ToString();
                        userEntity.Password = rdr["password"].ToString();
                        userEntity.securityKey = rdr["securityKey"].ToString();
                        userEntity.status = Convert.ToInt32(rdr["status"]);
                        userEntity.Usuario = rdr["usuario"].ToString();

                        lstUsers.Add(userEntity);

                    }
                    return lstUsers;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
                

            }
        }

        public UserEntity GetUserId(int id)
        {
            UserEntity userEntity = new UserEntity();

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("GetUserId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUser", id);

                try
                {
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        userEntity.ID = Convert.ToInt32(rdr["ID"]);
                        userEntity.Email = rdr["email"].ToString();
                        userEntity.Nombre = rdr["Nombre"].ToString();
                        userEntity.Password = rdr["password"].ToString();
                        userEntity.status = Convert.ToInt32(rdr["status"]);
                        userEntity.Usuario = rdr["Usuario"].ToString();
                        userEntity.securityKey = rdr["securityKey"].ToString();

                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }

                return userEntity;

            }


        }

        public bool InsertUser(UserEntity user)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("InsertUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("email", user.Email);
                cmd.Parameters.AddWithValue("Nombre", user.Nombre);
                cmd.Parameters.AddWithValue("password", user.Password);
                cmd.Parameters.AddWithValue("status", user.status);
                cmd.Parameters.AddWithValue("Usuario", user.Usuario);
                cmd.Parameters.AddWithValue("securityKey", user.securityKey);

                try
                {
                    con.Open();
                    var result = cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception e)
                {

                    throw new Exception("Error al Insertar Usuario\n" + e.Message);
                }

            }
        }

        public bool UpdateUser(UserEntity user)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("UpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("email", user.Email);
                cmd.Parameters.AddWithValue("Nombre", user.Nombre);
                cmd.Parameters.AddWithValue("password", user.Password);
                cmd.Parameters.AddWithValue("status", user.status);
                cmd.Parameters.AddWithValue("Usuario", user.Usuario);
                cmd.Parameters.AddWithValue("ID", user.ID);
                cmd.Parameters.AddWithValue("securityKey", user.securityKey);

                try
                {
                    con.Open();
                    var resul = cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {

                    throw new Exception("Error al Actualizar Usuario\n" + e.Message); ;
                }
            }
        }
    }


}
