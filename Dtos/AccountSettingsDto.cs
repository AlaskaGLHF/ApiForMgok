using System.ComponentModel.DataAnnotations;

namespace ApiForMgok.Dtos
{
    public static class AccountSettings
    {
        public class AccountSettingsDto
        {
           public string FullName { get; set; }

           public string PhoneNumber { get; set; }

           [EmailAddress]
           public string Email { get; set; }

           public string Login { get; set; }

           public string Password { get; set; }

           public string Comment { get; set; }

        }

        public class UpdateAccountSettingsDto
        { 
            
            public string FullName { get; set; }

            public string PhoneNumber { get; set; }

            [EmailAddress]
            public string Email { get; set; }

            public string Login { get; set; }

            public string Password { get; set; }

            public string Comment { get; set; }

        }
    }
}
