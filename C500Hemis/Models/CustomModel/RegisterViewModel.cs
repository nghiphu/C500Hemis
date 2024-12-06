using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models;

namespace C500Hemis.Models
{

    public class RegisterViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int IdPhong { get; set; }
    }
}


