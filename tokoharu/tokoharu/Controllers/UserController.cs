using System;
using System.Data;
using tokoharu.Models;
using TokoHaru.Repositories;

namespace TokoHaru.Controllers
{
    public class UserController
    {
        private readonly UserRepository _userRepository;

        public UserController(DBConnection dbConnection)
        {
            _userRepository = new UserRepository(dbConnection);
        }

        public DataTable GetAllUsers()
        {
            try
            {
                return _userRepository.GetAllUsers();
            }
            catch (Exception ex)
            {
                // Handle error (log or throw)
                throw new Exception("Failed to get users: " + ex.Message);
            }
        }

        public bool UpdateUser(int userId, string username)
        {
            try
            {
                return _userRepository.UpdateUser(userId, username);
            }
            catch (Exception ex)
            {
                // Handle error
                throw new Exception("Failed to update user: " + ex.Message);
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                return _userRepository.DeleteUser(userId);
            }
            catch (Exception ex)
            {
                // Handle error
                throw new Exception("Failed to delete user: " + ex.Message);
            }
        }
    }
}