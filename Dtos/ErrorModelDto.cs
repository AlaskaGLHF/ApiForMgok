using System;

namespace ApiForMgok.Dtos;

    public class ErrorModelDto()
    {
        public ErrorModelDto(string userResponse, string serverResponse) : this()
        {
            UserResponse = userResponse;
            ServerResponse = serverResponse;
        }

        public string UserResponse { get; set; }  //Эту ошибку отправляем пользователю

        public string ServerResponse { get; set; }  //Эту ошибку отправляем на логи сервера

}

