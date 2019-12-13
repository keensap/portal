using System;
using System.ComponentModel;
using KeenSap.Portal.Data.Entities;

namespace KeenSap.Portal.Service.Dto.Response
{
    public class UserGetDto : IDto
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public bool IsActive { get; set; }   
        
        public string Email { get; set; }   

        public string Username { get; set; }

        public string Token { get; set; }

    }
}
