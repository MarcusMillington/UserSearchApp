using API.DataAccess;
using API.Handlers.CreateUser;
using Moq;
using Shouldly;
using Xunit;

namespace API.UnitTests
{
    public class CreateUserTests
    {
        public CreateUserTests()
        {

        }

        [Theory]
        [InlineData("Alice", "Smith", "Programmer", "alicesmith@test.com", "0111 111111")]
        [InlineData("Bob", "Johnson", "QA", "bobjohnson@test.com", "0222 222222")]
        [InlineData("Charlie", "Brown", "BA", "charliebrown@test.com", "0333 333333")]
        public async Task CreateUser_UserIsCreated(string firstname, string lastname, string jobrole, string email, string telephone)
        {
            var mockUserRepository = new Mock<IUserRepository>();
            var handler = new CreateUserHandler(mockUserRepository.Object);

            handler.CreateUser(new CreateUserRequest
            {
                FirstName = firstname,
                LastName = lastname,
                JobRole = jobrole,
                Email = email,
                Telephone = telephone
            }).ShouldBeTrue();
        }
    }
}
