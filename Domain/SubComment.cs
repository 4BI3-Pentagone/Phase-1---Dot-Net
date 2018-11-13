using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public partial class SubComment
    {
        [Key]
        public int SubComID { get; set; }
        public string CommentMsg { get; set; }
        public Nullable<System.DateTime> CommentedDate { get; set; }
        public Nullable<int> ComID { get; set; }
        public Nullable<int> UserID { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual User User { get; set; }
    }
}
