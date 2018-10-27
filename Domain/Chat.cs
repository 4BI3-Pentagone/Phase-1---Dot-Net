using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Chat
    {

        public int IdChat { get; set; }
        public virtual Patient patient { get; set; }
        public virtual Doctor doctor { get; set; }
    }
}
