﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PazumAnia.Models
{
    public class RegisterBindingModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
