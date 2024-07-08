namespace EduPath.Test.Services;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{
    private readonly Mock<IDatabaseService> _databaseServiceMock;
    private readonly UserService _userService;

    private UserServiceTest(ITestOutputHelper testOutputHelper)
    {
        var databaseServiceMock = new Mock<IDatabaseService>();
        var logger = new TestLogger(testOutputHelper);
        var userService = new UserService
        {
            User = new User(),
            DatabaseService = databaseServiceMock.Object,
            Logger = logger
        };

        _databaseServiceMock = databaseServiceMock;
        _userService = userService;
    }

    public sealed class LoginTest : UserServiceTest
    {
        public LoginTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            _databaseServiceMock.Setup(d => d.GetUsersFromDatabase())
                .Returns(new Dictionary<string, User>
                {
                    ["user1"] = new() { UserName = "user1", Password = "password1", Email = "" },
                    ["user2"] = new() { UserName = "user2", Password = "password2", Email = "" }
                });

            _databaseServiceMock.Setup(d => d.GetUserFromKey(It.IsAny<string>()))
                .Returns((string key) => _databaseServiceMock.Object.GetUsersFromDatabase().GetValueOrDefault(key));
        }

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

    public sealed class RegisterTest : UserServiceTest
    {
        public RegisterTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            _databaseServiceMock.Setup(d => d.RegisterUser(It.Is<User>(u => u.UserName == "user1"))).Returns(false);
            _databaseServiceMock.Setup(d => d.RegisterUser(It.Is<User>(u => u.UserName == "user3"))).Returns(true);
        }

        [Fact]
        public void ShouldNotSetRegistered_WhenUserAlreadyExists()
        {
            _userService.Register(new User { UserName = "user1", Password = "password1", Email = "" });
            Assert.False(_userService.IsRegistered);
        }

        [Fact]
        public void ShouldSetRegistered_WhenSuccess()
        {
            _userService.Register(new User { UserName = "user3", Password = "password3", Email = "" });
            Assert.True(_userService.IsRegistered);
        }
    }
}