using API.Models;
using Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using Core.Common;
using Repository;

namespace API.Session
{
    public class Identity
    { 
        Repositories context = new Repositories();
        HttpResponse response;
        public ResultStatus Login(LoginRequest param)
        {
            ResultStatus rs = new ResultStatus();
            Password encrypted = new Password();
            string newPassword = encrypted.Encrypt(param.Password);
            if (context.User.IsAuthentic(param.Username, newPassword))
            {
                HttpCookie authCookie = FormsAuthentication.GetAuthCookie(param.Username, param.RememberMe);
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, param.Username);
                authCookie.Value = FormsAuthentication.Encrypt(newTicket);
                response.Cookies.Add(authCookie);
                rs.SetSuccess("Success");
            }
            else
            {
                rs.SetUnsuccess("Failed");
            }
            return rs;
        }
    }
}