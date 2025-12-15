using API.Handlers.CreateUser;
using API.Handlers.UserDetail;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Controller for user related endpoints.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserDetailHandler _userDetailHandlers;
        private ICreateUserHandler _createUserHandler;

        public UserController(IUserDetailHandler userDetailHandler, ICreateUserHandler createUserHandler)
        {
            _userDetailHandlers = userDetailHandler;
            _createUserHandler = createUserHandler;
        }

        /// <summary>
        /// Handles http get requests for a user specified by id.
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns>The users details</returns>
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<UserDetailResult> GetUser(int id)
        {
            return _userDetailHandlers.GetDetail(id);
        }

        /// <summary>
        /// Handles http put requests to create a new user.
        /// </summary>
        /// <param name="request">the new user details</param>
        /// <returns>True if a user was created.</returns>
        [HttpPost(Name = "CreateUser")]
        public ActionResult<bool> CreateUser(CreateUserRequest request)
        {
            return _createUserHandler.CreateUser(request);
        }
    }
}