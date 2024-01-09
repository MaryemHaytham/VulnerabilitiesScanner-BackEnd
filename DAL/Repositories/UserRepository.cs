using DAL.Entity;
using DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DAL.DbContext.AuthDbContext _AuthDbContext;

        public UserRepository(DAL.DbContext.AuthDbContext AuthDbContext) : base(AuthDbContext) 
        {
            _AuthDbContext = AuthDbContext;
        }

        public User GetUserByEmail(string email)
        {
            return _AuthDbContext.Users.FirstOrDefault(u => u.Email == email);
        }

    }
}
