namespace ApiForMgok.Dtos
{
    public static class AdminDto
    {

        public class AdminRequestsDto
        {

            public int Id { get; set; }

            public string Full_Name { get; set; }

            public int Address_Id { get; set; }

            public string Created_Date_Time { get; set; }

            public string Cabinet { get; set; }

            public int Status_Id { get; set; }

            public required int Employee_Id { get; set; }

        }

        public class AdminDetailRequestDto
        {

            public int Id{ get; set; }

            public int Status_Id { get; set; }

            public int Address_Id { get; set; }

            public string Cabinet { get; set; }

            public string Created_Date_Time { get; set; }

            public string Full_Name { get; set; }

            public int Employee_Id { get; set; }

            public string Employee_List  { get; set; } //Список сотрудиков для замены(Будет подключён через Include)

        }

        public class AdminNewResponsibleEmployeeRequestDto
        {

            public int Status_Id { get; set; }

            public int Address_Id { get; set; }

            public string Cabinet { get; set; }

            public string Created_Date_Time { get; set; }

            public string Full_Name { get; set; }

            public int Employee_Id { get; set; }
        }

        public class  AdminGetAllEmployeesDto
        {

            public int Id { get; set; }

            public string Full_Name { get; set; }

        }

        public class AdminDetailsEmployeeDTO
        {

            public int Id { get; set; }

            public string Full_Name { get; set; }

            public string Phone_Number { get; set; }

            public string Email { get; set; }

            public string Login { get; set; }

            public string Password { get; set; }

            public string Comment { get; set; }

            public bool Status { get; set; }

        }

        public class AdminUpdateEmployeeDto
        {

            public string Full_Name { get; set; }

            public string Phone_Number { get; set; }

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

            public int RoleId {get; set; }

        }

        public class AdminGetAllAdressesDTO
        {

            public int Id { get; set; }

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

            public int Id { get; set; }

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
