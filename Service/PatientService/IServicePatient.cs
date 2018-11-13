using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PatientService
{
    public interface IServicePatient
    {
       Patient getUserByID(string UserID);
        void Update(Patient r);
    }
}
