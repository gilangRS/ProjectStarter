using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
namespace Core.Common
{
    public class UserIdentity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class CoreIdentiry
    {
        private FormsAuthenticationTicket ticket;
        private UserIdentity user;
        
        public CoreIdentiry(FormsAuthenticationTicket ticket)
        {
        }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return ticket != null; }
        }

        public string Username
        {
            get { return user.Username; }
        }
        public string FirstName
        {
            get { return user.FirstName; }
        }
        public string LastName
        {
            get { return user.LastName; }
        }
        public string Name
        {
            get { return user.Username; }
        }
        public int UserId
        {
            get { return user.UserId; }
        }
    }
}
