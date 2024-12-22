namespace ApiForMgok.Dtos
{
    public static class UserDto
    {

        public class RequestUserDto
        {

            public int id { get; set; }

            public string FullName { get; set; }

            public  int AddressId { get; set; }

            public DateTime CreatedDateTime { get; set; }

            public string Cabinet { get; set; }

        }

         public class MyRequestUserDto
       {

            public int id { get; set; }

            public string FullName { get; set; }

            public int AddressId { get; set; }

            public DateTime CreatedDateTime { get; set; }

            public string Cabinet { get; set; }

            public int StatusId { get; set; }

            public int EmployeeId { get; set; }

        }

        public class RequestDetailsUserDTO
        {

            public int id { get; set; }

            public int StatusId { get; set; }

            public int AddressId { get; set; }

            public string Cabinet { get; set; }

            public DateTime CreatedDateTime { get; set; }

            public string FullName { get; set; }

            public string Description { get; set; }

            public string Photo { get; set; }

            public string CommentEmployee { get; set; }

        }

        public class UpdateDetailsUserDTO
        {

            public int StatusId { get; set; }

            public int AddressId { get; set; }

            public string Cabinet { get; set; }

            public DateTime CreatedDateTime { get; set; }

            public string FullName { get; set; }

            public string Description { get; set; }

            public string Photo { get; set; }

            public string CommentEmployee { get; set; }

        }

    }

}
