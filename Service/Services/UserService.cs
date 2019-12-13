using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KeenSap.Portal.Data.Entities;
using KeenSap.Portal.Data.Repository.Contract;
using KeenSap.Portal.Service.Dto.Request;
using KeenSap.Portal.Service.Dto.Response;
using KeenSap.Portal.Service.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace KeenSap.Portal.Service.Services
{

    public class UserService : GerericService<User, UserGetDto, UserCreateDto, UserUpdateDto>, IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository repository, IMapper mapper, IOptions<AppSettings> appSettings) : base(repository, mapper) //, IMapper mapper, IOptions<AppSettings> appSettings
        {
            _appSettings = appSettings.Value;
        }

        public UserGetDto Authenticate(string username, string password)
        {
            return AuthenticateAsync(username, password).Result;
        }

        /// <summary>
        /// Authenticate user by username and password
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>User Object</returns>
        public async Task<UserGetDto> AuthenticateAsync(string username, string password)
        {
            var user = await _repository.FindOneAsync(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    // new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return _mapper.Map<UserGetDto>(user);
        }

        // public IEnumerable<User> Get()
        // {
        //     // return users without passwords
        //     return _users.Select(x => {
        //         x.Password = null;
        //         return x;
        //     });
        // }

        // public User GetById(int id) {
        //     var user = _users.FirstOrDefault(x => x.Id == id);

        //     // return user without password
        //     if (user != null) 
        //         user.Password = null;

        //     return user;
        // }

        // protected override void OnUpdating(Common.EventArgs.UpdateEventArgs<User> e)
        // {
        //     var existing = _repository.Get(e.Id);
        //     existing.FirstName = e.Entity.FirstName;
        //     existing.LastName = e.Entity.LastName;
        //     existing.Email = e.Entity.Email;
        //     e.Entity = existing;
        // }
    }
}