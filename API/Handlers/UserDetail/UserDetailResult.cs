namespace API.Handlers.UserDetail
{
    /// <summary>
    /// The details of a user.
    /// </summary>
    public class UserDetailResult
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Telephone { get; set; }

        public string JobRole { get; set; }

        public string Email { get; set; }
    }
}
