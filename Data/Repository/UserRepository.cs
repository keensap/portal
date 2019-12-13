using System;
using KeenSap.Portal.Data.Entities;
using KeenSap.Portal.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace KeenSap.Portal.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
