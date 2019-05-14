using DBContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetData();
        bool IsAuthentic(string Username, string Password);
    }
}
