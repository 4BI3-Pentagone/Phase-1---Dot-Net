using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Domain;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class CourseConfig : EntityTypeConfiguration<Domain.Course>
    {

        public CourseConfig()
        {
<<<<<<< HEAD
=======
         // pull here
>>>>>>> 1c5205a395388ca9cafe71560e32660ff39a72a1
            //One to Many
          /*  WithMany(pr => pr.Visits)
            .HasForeignKey(d => d.CourseId)
            .WillCascadeOnDelete(false);*/
        }
    }
}
