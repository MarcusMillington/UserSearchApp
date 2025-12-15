namespace API.Handlers.CreateUser
{
    public interface ICreateUserHandler
    {
        bool CreateUser(CreateUserRequest request);
    }
}
