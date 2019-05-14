using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IResultStatus 
    {
        bool IsSuccess();
        void SetSuccess(string message);
        void SetUnsuccess(string message);
    }
}
