using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Comment
    {

       
        [Key]
        public int ComID { get; set; }
        public string CommentMsg { get; set; }
        public Nullable<System.DateTime> CommentedDate { get; set; }
        public Nullable<int> PostID { get; set; }
        public virtual Post Post { get; set; }
        public Nullable<int> UserID { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubComment> SubComments { get; set; }
        public Comment()
        {
            this.SubComments = new HashSet<SubComment>();
        }
    }
}


