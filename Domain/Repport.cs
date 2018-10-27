using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Repport
    {
        public int idRepport { get; set; }
        public String ReppotName { get; set; }
        public virtual Course course { get; set; }

    }
}
