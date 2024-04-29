using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using YourNamespace; // Replace with the appropriate namespace

[TestClass]
public class UserServiceTests
{
    [TestMethod]
    public async Task Login_ValidCredentials_ReturnsTrue()
    {
        // Arrange
        var mockUserManager = new Mock<UserManager<IdentityUser>>(
            Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);

        var userService = new YourUserService(mockUserManager.Object);

        var loginUser = new LoginUserDto
        {
            Email = "test@example.com",
            Password = "password123"
        };

        var fakeIdentityUser = new IdentityUser { Email = loginUser.Email };

        mockUserManager.Setup(m => m.FindByEmailAsync(loginUser.Email))
                       .ReturnsAsync(fakeIdentityUser);

        mockUserManager.Setup(m => m.CheckPasswordAsync(fakeIdentityUser, loginUser.Password))
                       .ReturnsAsync(true);

        // Act
        var result = await userService.Login(loginUser);

        // Assert
        Assert.IsTrue(result, "Login should return true for valid credentials.");
    }

    // Add more test methods for other scenarios like invalid email, invalid password, etc.
}
