<<<<<<< HEAD
﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PatientService
{
    public interface IServicePatient
=======
﻿namespace Service.PatientService
{
    internal interface IServicePatient
>>>>>>> 3bba1ba9699804c5097019f601711d2d51f211e7
    {
       Patient getUserByID(string UserID);
        void Update(Patient r);
    }
}