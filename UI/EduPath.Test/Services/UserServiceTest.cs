namespace EduPath.Test.Services;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{
    private readonly UserService _userService;

    private UserServiceTest(ITestOutputHelper testOutputHelper)
    {
        var databaseServiceMock = new Mock<IDatabaseService>();

        databaseServiceMock.Setup(d => d.GetUsersFromDatabase())
            .Returns(new Dictionary<string, User>
            {
                ["user1"] = new() { UserName = "user1", Password = "password1", Email = "" },
                ["user2"] = new() { UserName = "user2", Password = "password2", Email = "" }
            });

        databaseServiceMock.Setup(d => d.GetUserFromKey(It.IsAny<string>()))
            .Returns((string key) => databaseServiceMock.Object.GetUsersFromDatabase().GetValueOrDefault(key));

        var logger = new TestLogger(testOutputHelper);
        var userService = new UserService
        {
            User = new User(),
            DatabaseService = databaseServiceMock.Object,
            Logger = logger
        };

        _userService = userService;
    }

    public sealed class LoginTest(ITestOutputHelper testOutputHelper) : UserServiceTest(testOutputHelper)
    {
        [Fact]
        public void ShouldNotSetLoggedIn_WhenUserNotFound()
        {
            _userService.Login("user3", "password3");
            Assert.False(_userService.IsLoggedIn);
        }

        [Fact]
        public void ShouldNotSetLoggedIn_WhenPasswordIncorrect()
        {
            _userService.Login("user1", "password2");
            Assert.False(_userService.IsLoggedIn);
        }

        [Fact]
        public void ShouldSetLoggedIn_WhenSuccess()
        {
            _userService.Login("user1", "password1");
            Assert.True(_userService.IsLoggedIn);
        }
    }
}