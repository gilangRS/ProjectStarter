using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContext.Model
{
    public class ForgotPassword
    {
        [Key]
        public string Email { get; set; }
        public string GeneratedCode { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
