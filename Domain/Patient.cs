﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Patient : User
    {
        public int Insuranceid { get; set; }
        public virtual Course course { get; set; }
    }
}
