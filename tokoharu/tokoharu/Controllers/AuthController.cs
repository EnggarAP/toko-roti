using tokoharu.Models;
using TokoHaru.Repositories;

namespace TokoHaru.Controllers
{
    public class AuthController
    {
        private readonly UserRepository _userRepository;
        private readonly AdminRepository _adminRepository;

        public AuthController(DBConnection dbConnection)
        {
            _userRepository = new UserRepository(dbConnection);
            _adminRepository = new AdminRepository(dbConnection);
        }

        public bool RegisterUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            if (_userRepository.UsernameExists(username))
                return false;

            return _userRepository.Create(username, password);
        }

        public (bool success, bool isAdmin) Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return (false, false);

            if (_adminRepository.Authenticate(username, password))
                return (true, true);

            if (_userRepository.Authenticate(username, password))
                return (true, false);

            return (false, false);
        }
    }
}