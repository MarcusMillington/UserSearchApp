using API.DataAccess;

namespace API.Handlers.UserDetail
{
    /// <summary>
    /// Hanldes the retrieval of user details by id.
    /// </summary>
    public class UserDetailHandler : IUserDetailHandler
    {
        private IUserRepository _userRepository;

        public UserDetailHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Gets the details of a user by their id.
        /// </summary>
        /// <param name="id">The users id</param>
        /// <returns>The user with the specified id</returns>
        public UserDetailResult GetDetail(int id)
        {
            // get user with the specified id
            var result = _userRepository.GetUsers()
                .Where(u => u.Id == id)
                .FirstOrDefault();

            if(result != null)
            {
                return new UserDetailResult
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Telephone = result.Telephone,
                    JobRole = result.JobRole,
                    Email = result.Email
                };
            }

            return null;
        }
    }
}
