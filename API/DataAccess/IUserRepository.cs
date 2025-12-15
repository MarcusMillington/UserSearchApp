using API.Entities;

namespace API.DataAccess
{
    public interface IUserRepository
    {
        List<User> GetUsers();

        void Add(User user);
    }
}
