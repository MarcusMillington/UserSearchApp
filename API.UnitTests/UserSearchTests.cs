using API.DataAccess;
using API.Entities;
using API.Handlers.UserSearch;
using Moq;
using Shouldly;
using Xunit;

namespace TaskList.Application.Features.Tasks.Commands.CreateTask
{
    public class UserSearchTests
    {
        private List<User> users = new List<User>
        {
            new User { Id = 1, FirstName = "Alice", LastName = "Smith", JobRole = "Programmer", Email = "alicesmith@test.com", Telephone = "0111 111111" },
            new User { Id = 2, FirstName = "Bob", LastName = "Johnson", JobRole = "QA", Email = "bobjohnson@test.com", Telephone = "0222 222222" },
            new User { Id = 3, FirstName = "Charlie", LastName = "Brown", JobRole = "BA", Email = "charliebrown@test.com", Telephone = "0333 333333" }
        };

        public UserSearchTests()
        {

        }

        [Theory]
        [InlineData("Al", 1)]
        [InlineData("bO", 1)]
        [InlineData("Ch", 1)]
        [InlineData("ZZ", 0)]
        public async Task SearchUsers_SearchMatchesOnFirstname(string search, int expected)
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetUsers()).Returns(users);

            var handler = new UserSearchHandler(mockUserRepository.Object);

            handler.SearchUsers(search).Count.ShouldBe(expected);
        }

        [Theory]
        [InlineData("SM", 1)]
        [InlineData("jo", 1)]
        [InlineData("Br", 1)]
        [InlineData("ZZ", 0)]
        public async Task SearchUsers_SearchMatchesOnLastname(string search, int expected)
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetUsers()).Returns(users);

            var handler = new UserSearchHandler(mockUserRepository.Object);

            handler.SearchUsers(search).Count.ShouldBe(expected);
        }
    }
}