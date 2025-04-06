using System;
using LibMan.Entities;

namespace libMan.Services.Registration;

public class RegistrationService : IRegistrationService
{
    private readonly IMemberRepository _memberRepository;

    public RegistrationService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }
    public Member Register(Member member)
    {
       var addedMember = _memberRepository.Add(member);
        return addedMember;
    }
}
