using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{

    public class DocterModels:Doctor
    {
       
        public string FirstName { get; set; }
        public string lastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? birthDate { get; set; }
        public string adress { get; set; }
       
        public string ImageName { get; set; }
        
    }
}