using System.Text.Json.Serialization;

namespace ApiForMgok.Dtos
{
    public static class TelegramBotDto
    {

        public class TelegramBotRequestDto
        {

            public int ChatId { get; set; }

            public int AddressId { get; set; }

            public string Cabinet { get; set; }
            
            public string FullName { get; set; }

            public string PhoneNumber { get; set; }

            public string Description { get; set; }

            public string Photo { get; set; }
            
        }

        public class TelegramBotResponseDto
        {

            public int Id { get; set; }

            public int ChatId { get; set; }

            public  int AddressId { get; set; }

            public string Cabinet { get; set; }

            public string FullName { get; set; }

            public string PhoneNumber { get; set; }

            public string Description { get; set; }

            public DateTime CreatedDateTime { get; set; }

            public int? StatusId { get; set; }

    }
    }
}
