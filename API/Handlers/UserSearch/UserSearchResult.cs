namespace API.Handlers.UserSearch
{
    /// <summary>
    /// The infromation returned for a user search result.
    /// </summary>
    public class UserSearchResult
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
