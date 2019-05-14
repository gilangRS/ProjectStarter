using Core;
using DBContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IForgotPasswordRepository
    {
        ResultStatus InsertGeneratedCode(string Email, string GeneratedCode);
        ForgotPassword CheckLinkExpiration(string GeneratedCode);

        IEnumerable<User> GetUsers();
    }
}
