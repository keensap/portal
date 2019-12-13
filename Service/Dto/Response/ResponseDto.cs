using System;
using System.Collections.Generic;
using KeenSap.Portal.Data.Entities;

namespace KeenSap.Portal.Service.Dto.Response
{
    public class ResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public ResponseDto()
        {
            Errors = new List<string>();
        }

        public ResponseDto(bool success, string message)
        {
            Errors = new List<string>();
            Message = message;
            Success = success;
        }
    }
}
