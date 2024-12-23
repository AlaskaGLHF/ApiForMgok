using System;

namespace ApiForMgok.Dtos;

    public class ErrorModelDto()
    {

        public string User_Response { get; set; }  //Эту ошибку отправляем пользователю

        public string Server_Response { get; set; }  //Эту ошибку отправляем на логи сервера

}

