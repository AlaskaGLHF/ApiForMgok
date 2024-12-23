namespace ApiForMgok.Dtos
{
    public static class UserDto
    {

        public class RequestUserDto
        {

            public int Id { get; set; }

            public string Full_Name { get; set; }

            public  int Address_Id { get; set; }

            public DateTime Created_Date_Time { get; set; }

            public string Cabinet { get; set; }

        }

         public class MyRequestUserDto
       {

            public int Id { get; set; }

            public string Full_Name { get; set; }

            public int Address_Id { get; set; }

            public DateTime Created_Date_Time { get; set; }

            public string Cabinet { get; set; }

            public int Status_Id { get; set; }

            public int Employee_Id { get; set; }

        }

        public class RequestDetailsUserDTO
        {

            public int Id { get; set; }

            public int Status_Id { get; set; }

            public int Address_Id { get; set; }

            public string Cabinet { get; set; }

            public DateTime Created_Date_Time { get; set; }

            public string Full_Name { get; set; }

            public string Description { get; set; }

            public string Photo { get; set; }

            public string Comment_Employee { get; set; }

        }

        public class UpdateDetailsUserDTO
        {

            public int Status_Id { get; set; }

            public int Address_Id { get; set; }

            public string Cabinet { get; set; }

            public DateTime Created_Date_Time { get; set; }

            public string Full_Name { get; set; }

            public string Description { get; set; }

            public string Photo { get; set; }

            public string Comment_Employee { get; set; }

        }

    }

}
