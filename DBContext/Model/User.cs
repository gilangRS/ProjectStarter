﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContext.Model
{
    public class User : BaseModel
    {
        public string Password { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
    }
}
