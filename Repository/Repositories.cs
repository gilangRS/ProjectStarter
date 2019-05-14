using Repository.Interface;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repositories
    {
        public ITestRepository Test { get; set; }
        public IUserRepository User { get; set; }

        public IForgotPasswordRepository ForgotPassword { get; set; }
        public Repositories()
        {
            Test = new TestRepository();
            User = new UserRepository();
            ForgotPassword = new ForgotPasswordRepository();
        }

    }
}
