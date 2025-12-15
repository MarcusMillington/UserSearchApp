using API.DataAccess;
using API.Entities;
using API.Handlers.UserDetail;
using Moq;
using Shouldly;
using Xunit;

namespace TaskList.Application.Features.Tasks.Commands.CreateTask
{
    public class UserDetailTests
    {
        private List<User> users = new List<User>
        {
            new User { Id = 1, FirstName = "Alice", LastName = "Smith", JobRole = "Programmer", Email = "alicesmith@test.com", Telephone = "0111 111111" },
            new User { Id = 2, FirstName = "Bob", LastName = "Johnson", JobRole = "QA", Email = "bobjohnson@test.com", Telephone = "0222 222222" },
            new User { Id = 3, FirstName = "Charlie", LastName = "Brown", JobRole = "BA", Email = "charliebrown@test.com", Telephone = "0333 333333" }
        };

        public UserDetailTests()
        {

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetUserDetail_IfUserExists_DetailAreReturned(int id)
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetUsers()).Returns(users);

            var handler = new UserDetailHandler(mockUserRepository.Object);

            handler.GetDetail(id).ShouldNotBeNull();
        }
    }
}