namespace ApiForMgok.Dtos
{
    public static class TelegramBotDto
    {

        public class TelegrammBotRequestDTO
        {

            public int ChatId { get; set; }

            public string AddressId { get; set; }

            public string Cabinet { get; set; }

            public string PhoneNumber { get; set; }

            public string Description { get; set; }

            public string Photo { get; set; }

        }

        public class TelegrammBotResponseDTO
        {

            public int Id { get; set; }

            public int ChatId { get; set; }

            public  int AddressId { get; set; }

            public string Cabinet { get; set; }

            public string FullName { get; set; }

            public string PhoneNumber { get; set; }

            public string Description { get; set; }

            public string CreatedDateTime { get; set; }

            public int StatusId { get; set; }

    }
    }
}
