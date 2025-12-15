using API.DataAccess;
using API.Entities;

namespace API.Handlers.CreateUser
{
    /// <summary>
    /// Handles the creation of new user records in the database.
    /// </summary>
    public class CreateUserHandler : ICreateUserHandler
    {
        private IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="request">The details of the new user</param>
        /// <returns>True if the new user was created</returns>
        public bool CreateUser(CreateUserRequest request)
        {
            try
            {
                _userRepository.Add(new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Telephone = request.Telephone,
                    JobRole = request.JobRole,
                    Email = request.Email
                });
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
