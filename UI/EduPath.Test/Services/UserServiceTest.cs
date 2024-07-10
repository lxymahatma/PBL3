namespace EduPath.Test.Services;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{
    private const string ExistedUserName = "user1";
    private const string ExistedUserPassword = "password1";
    private const string ExistedUserEmail = "email1@gmail.com";
    private const string NonExistedUserName = "user2";
    private const string NonExistedUserPassword = "password2";
    private const string NonExistedUserEmail = "email2@gmail.com";

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
            _databaseServiceMock.Setup(d => d.GetUserFromKey(ExistedUserName))
                .Returns(new User { UserName = ExistedUserName, Password = ExistedUserPassword, Email = ExistedUserEmail });
            _databaseServiceMock.Setup(d => d.GetUserFromKey(ExistedUserEmail))
                .Returns(new User { UserName = ExistedUserName, Password = ExistedUserPassword, Email = ExistedUserEmail });
        }

        [Fact]
        public void ShouldNotSetLoggedIn_WhenUserNotFound()
        {
            _userService.Login(NonExistedUserName, NonExistedUserPassword);
            Assert.False(_userService.IsLoggedIn);
        }

        [Fact]
        public void ShouldNotSetLoggedIn_WhenPasswordIncorrect()
        {
            _userService.Login(ExistedUserName, NonExistedUserPassword);
            Assert.False(_userService.IsLoggedIn);
        }

        [Fact]
        public void ShouldSetLoggedIn_WhenUsingUserNameSuccess()
        {
            _userService.Login(ExistedUserName, ExistedUserPassword);
            Assert.True(_userService.IsLoggedIn);
        }

        [Fact]
        public void ShouldSetLoggedIn_WhenUsingEmailSuccess()
        {
            _userService.Login(ExistedUserEmail, ExistedUserPassword);
            Assert.True(_userService.IsLoggedIn);
        }

        [Fact]
        public void ShouldSetUser_WhenLoginSuccess()
        {
            _userService.Login(ExistedUserName, ExistedUserPassword);
            Assert.NotNull(_userService.User);
            Assert.Equal(ExistedUserName, _userService.User.UserName);
            Assert.Equal(ExistedUserEmail, _userService.User.Email);
            Assert.Equal(ExistedUserPassword, _userService.User.Password);
        }
    }

    public sealed class RegisterTest : UserServiceTest
    {
        public RegisterTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            _databaseServiceMock.Setup(d => d.RegisterUser(It.Is<User>(u => u.UserName == ExistedUserName))).Returns(false);
            _databaseServiceMock.Setup(d => d.RegisterUser(It.Is<User>(u => u.UserName == NonExistedUserName))).Returns(true);
        }

        [Fact]
        public void ShouldNotSetRegistered_WhenUserAlreadyExists()
        {
            _userService.Register(new User { UserName = ExistedUserName, Password = ExistedUserPassword, Email = ExistedUserEmail });
            Assert.False(_userService.IsRegistered);
        }

        [Fact]
        public void ShouldSetRegistered_WhenSuccess()
        {
            _userService.Register(new User { UserName = NonExistedUserName, Password = NonExistedUserPassword, Email = NonExistedUserEmail });
            Assert.True(_userService.IsRegistered);
        }
    }

    public sealed class DeleteCurrentUserTest : UserServiceTest
    {
        public DeleteCurrentUserTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            _databaseServiceMock.Setup(d => d.GetUserFromKey(ExistedUserName))
                .Returns(new User { UserName = ExistedUserName, Password = ExistedUserPassword, Email = ExistedUserEmail });
            _userService.Login(ExistedUserName, ExistedUserPassword);
            _userService.DeleteCurrentUser();
            _databaseServiceMock.Setup(d => d.GetUserFromKey(It.IsAny<string>()));
        }

        [Fact]
        public void ShouldSetLoggedInFalse_WhenDeleteCurrentUser()
        {
            Assert.False(_userService.IsLoggedIn);
        }

        [Fact]
        public void ShouldSetRegisteredFalse_WhenDeleteCurrentUser()
        {
            Assert.False(_userService.IsRegistered);
        }

        [Fact]
        public void ShouldNotAbleLogin_WhenCurrentUserDeleted()
        {
            _userService.Login(ExistedUserName, ExistedUserPassword);
            Assert.False(_userService.IsLoggedIn);
        }
    }
}