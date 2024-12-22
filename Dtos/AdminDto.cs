namespace ApiForMgok.Dtos
{
    public static class AdminDto
    {

        public class AdminRequestDto
        {

            public int id { get; set; }

            public string FullName { get; set; }

            public int AddressId { get; set; }

            public string CreatedDateTime { get; set; }

            public string Cabinet { get; set; }

            public int StatusId { get; set; }

            public int EmployeeId { get; set; }

        }

        public class AdminDetailRequestDto
        {

            public int id { get; set; }

            public int StatusId { get; set; }

            public int AddressId { get; set; }

            public string Cabinet { get; set; }

            public string CreatedDateTime { get; set; }

            public string FullName { get; set; }

            public int EmployeeId { get; set; }

            public string EmployeeList  { get; set; } //Список сотрудиков для замены(Будет подключён через Include)

        }

        public class AdminNewResponsibleEmployeeRequestDto
        {

            public int StatusId { get; set; }

            public int AddressId { get; set; }

            public string Cabinet { get; set; }

            public string CreatedDateTime { get; set; }

            public string FullName { get; set; }

            public int EmployeeId { get; set; }
        }

        public class  AdminGetAllEmployeesDto
        {

            public int id { get; set; }

            public string FullName { get; set; }

        }

        public class AdminDetailsEmployeeDTO
        {

            public int id { get; set; }

            public string FullName { get; set; }

            public string PhoneNumber { get; set; }

            public string Email { get; set; }

            public string Login { get; set; }

            public string Password { get; set; }

            public string Comment { get; set; }

            public bool Status { get; set; }

        }

        public class AdminUpdateEmployeeDto
        {

            public string FullName { get; set; }

            public string PhoneNumber { get; set; }

            public string Email { get; set; }

            public string Login { get; set; }

            public string Password { get; set; }

            public string Comment { get; set; }

            public bool Status { get; set; }

        }

        public class AdminAddEmployeeDto
        {

            public string FullName { get; set; }

            public string PhoneNumber { get; set; }

            public string Email { get; set; }

            public string Login { get; set; }

            public string Password { get; set; }

            public bool Status { get; set; }

            public int role_id { get; set; }

        }

        public class AdminGetAdressDTO
        {

            public int id { get; set; }

            public string Address { get; set; }

            public bool Status { get; set; }

        }

        public class AdminCreateAdressDto
        {

            public string Address { get; set; }

            public bool Status { get; set; }

        }

        public class AdminProfileDto
        {

            public int id { get; set; }

            public string FullName { get; set; }

            public string PhoneNumber { get; set; }

            public string Email { get; set; }

            public string Comment { get; set; }

        }

        public class AdminUpdateProfileDto
        {

            public string FullName { get; set; }

            public string PhoneNumber { get; set; }

            public string Email { get; set; }

            public string Comment { get; set; }

        }

    }
}
