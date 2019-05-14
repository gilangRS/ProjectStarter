using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ResultStatus : IResultStatus
    {
        public string message { get; set; }
        private bool Status { get; set; }
        
        public bool IsSuccess()
        {
            return Status;
        }

        public void SetSuccess(string message)
        {
            Status = true;
            this.message = message;
        }
        public void SetUnsuccess(string message)
        {
            Status = false;
            this.message = message;
        }
    }
    
}
