using Core;
using Core.Common;
using DBContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class ForgotPasswordFacade
    {
        
        #region Public Method
        public string getGeneratedCode(string email)
        {
            string code = string.Empty;
            SHA512 codedEmail = SHA512Cng.Create();
            email += email + getDateOnString();
            byte[] passHash = Encoding.UTF8.GetBytes(email);
            byte[] Encrypted = codedEmail.ComputeHash(passHash);
            code = getStringFromHash(Encrypted);
            return code;
        }

        public ResultStatus SendEmail(User user, string generatedCode)
        {
            ResultStatus rs = new ResultStatus();
            Common common = new Common();
            generatedCode += "'" + generatedCode + "'";
            string bodyEmail = @"<html>
                      <body>
                      <p>Dear "+ user.Username + @",</p>
                      <p>Seems like you forgot your password.
                      <br>Here's a link to reset your password: http://localhost:52298/api/User/Reset?generatedCode="+generatedCode+@".</p>
                      <p>Sincerely,<br>-Jack</br></p>
                      </body>
                      </html>
                     ";

            string from = "gilangraysadewo@gmail.com";
            List<string> to = new List<string>();
            to.Add("gilangraysadewo@gmail.com");

            //StringBuilder sb = new StringBuilder();
            //sb = composeBody(user, generatedCode);

            rs = common.composeEmail(from, to, bodyEmail);
            return rs;
        }
        #endregion

        #region Private Method
        private string getDateOnString()
        {
            string dateString = string.Empty;
            DateTime date = DateTime.Now;
            dateString += date.Year.ToString() + date.Month.ToString() + date.Date.ToString();
            return dateString;
        }

        private string getStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("x2"));
            }
            return result.ToString();
        }
        private StringBuilder composeBody(User user, string generatedCode)
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("Dear " + user.Username + ",");
            sb.AppendLine("Seems like you forgot your password");
            sb.AppendLine("Here's the link to reset:");
            sb.AppendLine(@"http://localhost:52298/api/User/Reset?generatedCode='"+generatedCode+"'");

            return sb;
        }
        #endregion
    }
}
