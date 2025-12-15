using API.Handlers.UserSearch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Controller for user related endpoints.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserSearchController : ControllerBase
    {
        private IUserSearchHandler _userSearchHandler;

        public UserSearchController(IUserSearchHandler userSearchHandler)
        {
            _userSearchHandler = userSearchHandler;
        }

        /// <summary>
        /// Handles http get requests for a user specified by id.
        /// </summary>
        /// <param name="search">The search string</param>
        /// <returns>The matching users</returns>
        [HttpGet("{search}", Name = "SearchUsers")]
        public List<UserSearchResult> SearchUsers(string search)
        {
            return _userSearchHandler.SearchUsers(search);
        }
    }
}
