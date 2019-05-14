using DBContext;
using DBContext.Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        TestingContext context = new TestingContext();

        public UserRepository()
        {
            context.User.AsNoTracking();
        }

        public IEnumerable<User> GetData()
        {
            return context.User.ToList();
        }

        public bool IsAuthentic(string Username, string Password)
        {
            return context.User.Any(x => x.Username.Equals(Username) && x.Password.Equals(Password));
        }
    }
}
