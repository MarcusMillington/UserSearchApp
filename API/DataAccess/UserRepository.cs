using API.Entities;

namespace API.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private UserSearchDbContext _dbContext;

        public UserRepository(UserSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetUsers()
        {
            return _dbContext.User.ToList();
        }

        public void Add(User user)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
