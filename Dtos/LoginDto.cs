using System;

namespace ApiForMgok.Dtos;

    public class LoginDto()
    {
       public string Login { get; set; }  //Логин сотрудника

       public string Password { get; set; }  //Пароль сотрудника

    }

public class ResponeLoginDto()
{

    public string JwtToken { get; set; } //JWT токен выдаваемый после авторизации

}
