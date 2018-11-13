using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Reponse
    {
        [Key]

        public int IdReponse { get; set; }
        public String reponse { get; set; }

    }
}
