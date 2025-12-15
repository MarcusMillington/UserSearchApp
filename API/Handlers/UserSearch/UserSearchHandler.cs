using API.DataAccess;
using API.Entities;

namespace API.Handlers.UserSearch
{
    /// <summary>
    /// Handles searching for users by first or last name.
    /// </summary>
    public class UserSearchHandler : IUserSearchHandler
    {
        private IUserRepository _userRepository;

        public UserSearchHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Handles searching for users by first or last name.
        /// </summary>
        /// <param name="search">The search string</param>
        /// <returns>The id, firstname, lastname of the matching users</returns>
        public List<UserSearchResult> SearchUsers(string search)
        {
            var results = _userRepository.GetUsers()
                .Where(u => IsMatch(u, search))
                .Select(u => new UserSearchResult 
                { 
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                });

            return results.ToList();
        }

        /// <summary>
        /// Checks if the user matches the search criteria.
        /// </summary>
        /// <param name="user">The user being checked.</param>
        /// <param name="search">The search criteria</param>
        /// <returns>True if the user matches</returns>
        private bool IsMatch(User user, string search)
        {
            if(user.FirstName.StartsWith(search, StringComparison.OrdinalIgnoreCase))
                return true;

            if (user.LastName.StartsWith(search, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }
    }
}
