using LibMan.Data;
using LibMan.Entities;
using libMan.Services;
using Moq;
namespace LibManServiceTests;

public class DefaultAuthServiceTest
{
    private DefaultAuthService _authService;

    [SetUp]
    public void SetUp()
    {
        
        var mockAdminRepositary = new Mock<IAdminRepositary>();
        _authService = new DefaultAuthService(mockAdminRepositary.Object);
      
      //Creating mock to test GetByEmail funcitonality of IAdmiRepositary

      //Mock object with email  hadi@gmail.com
      mockAdminRepositary.Setup(m => m.GetByEmail("hadi@gmail.com")).Returns(new Admin{
        Name = "Hadi",
        Email = "hadi@gmail.com",
        Password ="12345",
        Id = 1
      });
      //Mock object with email wrongpassword@gmail.com
      mockAdminRepositary.Setup(m => m.GetByEmail("wrongpassword@gmail.com")).Returns(new Admin{
        Name = "Hadi",
        Id= 1,
        Email = "wrongpassword@gmail.com",
        Password = "12345@@"
      });

      //if userDoesNotExist@gmail.com is used in GetByEmail throw exception
      mockAdminRepositary.Setup(m => m.GetByEmail("userDoesNotExist@gmail.com"))
                        .Throws(new EmailNotFoundException("EmailNotFoundException"));
    }


    //Scenario 1: Valid Email and Valid Password  - Returns True
        // GetByEmail must return a valid admin object with same email and same password

    //Scenario 2: Valid Email and Invalid Password - Returns False
        // GetByEmail must return a valid admin object with same email and different password

    //Scenario 3: Invalid Email and Valid Password - Exception -> EmailNotFoundException
        // GetByEmail must throw EmailNotFoundException



    //Scenario 1: Valid Email and Valid Password  - Returns True
    [Test]
    
    public void LoginTest_validCredential_ReturnTrue()
    {
        //Arrange
        var email = "hadi@gmail.com";
        var password = "12345";

        //Act
        var result = _authService.Login(email, password);

        //ASsert
        Assert.That(result, Is.True);
    }

    [Test]
    public void LoginTest_ValidEmailInvalidPassword_ReturnsFalse()
    {
        //Arrange
        var email= "wrongpassword@gmail.com";
        var password= "wrong12345";

        //Act
        var result = _authService.Login(email, password);

        //Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void LoginTest_InvalidEmail_ThrowsEmailNotFOundException()
    {
        //Arrange
        var email =  "userDoesNotExist@gmail.com";
        var password ="user12345";

        //Act
        Assert.Throws<EmailNotFoundException>(() => _authService.Login(email, password));
    }
    
    
}
