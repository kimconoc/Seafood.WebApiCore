﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Base.ViewModel
{
    public class UserCreateModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Sex { get; set; }
        public string Mobile { get; set; }
    }
}
