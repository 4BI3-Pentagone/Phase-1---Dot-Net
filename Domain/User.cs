﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum Gender { male, female }

    public class User
    {
        public int UserId { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public DateTime birthDate { get; set; }
        public String adress { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public Gender gender { get; set; }
    }
}
