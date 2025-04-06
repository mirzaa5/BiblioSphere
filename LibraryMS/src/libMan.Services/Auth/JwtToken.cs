using System;

namespace libMan.Services.Auth;

public class JwtToken
{
    public string Token {get; set;}

   public  DateTime Expiration {get; set;}

   public bool isAdmin {get; set;}
}
