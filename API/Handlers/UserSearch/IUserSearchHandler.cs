namespace API.Handlers.UserSearch
{
    public interface IUserSearchHandler
    {
        List<UserSearchResult> SearchUsers(string search);
    }
}
