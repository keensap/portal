using System;
using System.Collections.Generic;
using KeenSap.Portal.Data.Entities;

namespace KeenSap.Portal.Service.Dto.Response
{
    public class ResponseDto<T> : ResponseDto
    {
        public T Result { get; set; }

        public ResponseDto()
        {
            Errors = new List<string>();
        }

        public ResponseDto(T result, bool success, string message)
        {
            Errors = new List<string>();
            Message = message;
            Result = result;
            Success = success;
        }
    }
}
