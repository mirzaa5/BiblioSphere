using LibMan.Entities;
using LibMan.Data;

namespace LibManRepoTests;

public class AdminRepositaryTest
{
    //1. Dependecny Inject dbcontext , AdminRepositary
    //2. [Setup] Initialize both dependencies
    //3. SetUp test [Test], Arrange data, action required, Assert if result  is right

    LibDbContext _dbContext;
    AdminRepositary _adminRepositary;

    [SetUp]
    public void setup()
    {
        _dbContext = new LibDbContext();
        _adminRepositary = new AdminRepositary(_dbContext);
    }

    [Test]

//
    public void AddAdmin_ValidateData_ReturnNewAdmin()
    {
        //Arange
        var admin = new Admin();
        admin.Name="Jhonathan";
        admin.Email=$"xyz{Guid.NewGuid()}@gmail.com";
        admin.Password="12345";

        //Act 
        var result = _adminRepositary.Add(admin);

        //ASert
        Assert.That(result, Is.Not.Null); //makes sure that admin added
        Assert.That(result.Id, Is.GreaterThan(0));

    }

    //Test to check that if we AdAdmin, DuplicateEmail is checked, if so throw DuplicateEmail Exception
    [Test]
    public void AddAdmin_CheckDuplicate_ThrowDuplicateException()
    {
        //Arrange
        var admin = new Admin();
        admin.Name = "Jhonathan";
        admin.Email=$"xyz{Guid.NewGuid()}@gmail.com";
        admin.Password = "12546";

        //Act
        //Add function returns admin, if sucess
        var result = _adminRepositary.Add(admin);

        //Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.GreaterThan(0));
        
        //same admin added, Should throw "DublicateEmailException"
        Assert.Throws<DublicateEmailException>(() => _adminRepositary.Add(admin));

    }


    //A test to throw duplicate excepion, case innsensistive

    [TestCase("hadi55@gmail.com")]
    [TestCase("Hadi55@Gmail.com")]
    [TestCase("HADI55@GMAIL.COM")]
    [TestCase("hadi55@GMAIL.com")]
    [TestCase("hadi55@GMAIL.com")]
    public void AddAdmin_DuplicateExcepDiffCases_ThrowDuplicateExcpetion(string email)
    {
        var admin = new Admin();
        admin.Email = email;
        admin.Password = "12345";
        admin.Name ="Hadi";

        //Add admin for first time
        var result = _adminRepositary.Add(admin);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.GreaterThan(0) );

        //Then check for duplicate
        //So even though you're calling .ToLower() in C# repositary, PostgreSQL might still treat differently cased emails as unique if your email column is case-sensitive
        // Enforec ToLower() .
        admin.Email = admin.Email.ToLower(); // hadi55@gmail.com 
        Assert.Throws<DublicateEmailException>(() => _adminRepositary.Add(admin));
    }





    //TearDown makes sure Dbcontext is closed to avoid memory leak
    [TearDown]
    public void TearDown()
    {
        _dbContext.Dispose();
    }





}


/*
Qs, Tear Down Explanation
Duplicate Exception thrown but test nnot passing! adde email "xyz@gmail.com" on all add admins 
without using Guid.NewGuid() for random email numbers
Test passed after adding this
*/
