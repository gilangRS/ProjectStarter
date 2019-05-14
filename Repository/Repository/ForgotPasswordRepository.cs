using Core;
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
    public class ForgotPasswordRepository : IForgotPasswordRepository
    {
        TestingContext context = new TestingContext();

        public ForgotPasswordRepository()
        {
            context.ForgotPassword.AsNoTracking();
        }
        public ResultStatus InsertGeneratedCode(string Email, string GeneratedCode)
        {
            ResultStatus rs = new ResultStatus();
            ForgotPassword forgot = new ForgotPassword();
            try
            {
                forgot.Email = Email;
                forgot.GeneratedCode = GeneratedCode;
                forgot.CreatedTime = DateTime.Now;
                context.ForgotPassword.Add(forgot);
                context.SaveChanges();

                rs.SetSuccess("Code Generated Successfully");
            }
            catch (Exception e)
            {
                rs.SetUnsuccess(e.Message);
            }
            return rs;
        }

        public ForgotPassword CheckLinkExpiration(string GeneratedCode)
        {
            return context.ForgotPassword.Where(x => x.GeneratedCode.Equals(GeneratedCode)).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return context.User.ToList();
        }
    }
}
