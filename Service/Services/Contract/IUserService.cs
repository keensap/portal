using System.Collections.Generic;
using System.Threading.Tasks;
using KeenSap.Portal.Data.Entities;
using KeenSap.Portal.Service.Dto.Request;
using KeenSap.Portal.Service.Dto.Response;
using KeenSap.Portal.Service.Services.Contract;

namespace KeenSap.Portal.Service.Services
{
    public interface IUserService : IGenericService<User, UserGetDto, UserCreateDto, UserUpdateDto>
    {
        UserGetDto Authenticate(string username, string password);
        Task<UserGetDto> AuthenticateAsync(string username, string password);
    }
}