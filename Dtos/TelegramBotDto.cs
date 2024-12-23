namespace ApiForMgok.Dtos
{
    public static class TelegramBotDto
    {

        public class TelegrammBotRequestDTO
        {

            public int Chat_Id { get; set; }

            public string Address_Id { get; set; }

            public string Cabinet { get; set; }

            public string Phone_Number { get; set; }

            public string Description { get; set; }

            public string Photo { get; set; }

        }

        public class TelegrammBotResponseDTO
        {

            public int Id { get; set; }

            public int Chat_Id { get; set; }

            public  int Address_Id { get; set; }

            public string Cabinet { get; set; }

            public string Full_Name { get; set; }

            public string Phone_Number { get; set; }

            public string Description { get; set; }

            public string Created_Date_Time { get; set; }

            public int Status_Id { get; set; }

    }
    }
}
