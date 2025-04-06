using System;
using LibMan.Entities;

namespace libMan.Services.Registration;

public interface IRegistrationService
{
    Member Register(Member member);
}
