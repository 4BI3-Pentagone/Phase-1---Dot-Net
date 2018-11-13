using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Question
    {
        [Key]
        public int idQuestion { get; set; }
        public String  Titre{ get; set; }
        public String question { get; set; }
        public DateTime Datetime { get; set; }


    }
}
