namespace ApiForMgok.Dtos
{
    public class AccountSettingsDTO
    {
        string FullName { get; set; }

        string PhoneNumber { get; set; }

        string Email { get; set; }

        string Login { get; set; }

        string Password { get; set; }

        string Comment { get; set; }

    }

    public class UpdateAccountSettingsDTO 
    {

        string Full_Name { get; set; }

        string Phone_Number { get; set; }

        string Email { get; set; }

        string Login { get; set; }

        string Password { get; set; }

        string Comment { get; set; }

    }
}
