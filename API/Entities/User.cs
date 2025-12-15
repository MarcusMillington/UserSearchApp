namespace API.Entities
{
    /// <summary>
    /// User entity representing a user in the system.
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Telephone { get; set; }

        public string JobRole { get; set; }

        public string Email { get; set; }
    }
}
