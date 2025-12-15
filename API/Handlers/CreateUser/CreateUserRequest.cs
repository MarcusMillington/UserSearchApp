namespace API.Handlers.CreateUser
{
    /// <summary>
    /// Defines the details required to create a new user.
    /// </summary>
    public class CreateUserRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Telephone { get; set; }

        public string JobRole { get; set; }

        public string Email { get; set; }
    }
}
