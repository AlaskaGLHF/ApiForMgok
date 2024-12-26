namespace ApiForMgok.Dtos
{
    public static class UserDto
    {

        public class RequestUserDto
        {

            public int Id { get; set; }

            public string FullName { get; set; }

            public  int AddressId { get; set; }

            public DateTime CreatedDateTime { get; set; }

            public string Cabinet { get; set; }

        }

         public class MyRequestUserDto
       {

            public int Id { get; set; }

            public string FullName { get; set; }

            public int AddressId { get; set; }

            public DateTime CreatedDateTime { get; set; }

            public string Cabinet { get; set; }

            public int StatusId { get; set; }

            public int EmployeeId { get; set; }

        }

        public class RequestDetailsUserDto
        {

            public int Id { get; set; }

            public int StatusId { get; set; }

            public int AddressId { get; set; }

            public string Cabinet { get; set; }

            public DateTime CreatedDateTime { get; set; }

            public string FullName { get; set; }

            public string Description { get; set; }

            public string Photo { get; set; }

            public string CommentEmployee { get; set; }

        }

        public class UpdateDetailsUserDto
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
