using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Domain;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class CourseConfig : EntityTypeConfiguration<Domain.Course>
    {

        public CourseConfig()
        {
            //One to Many
            /*  WithMany(pr => pr.Visits)
              .HasForeignKey(d => d.CourseId)
              .WillCascadeOnDelete(false);*/



         /*   HasMany(d => d.Visits).WithMany(mp => mp.Courses).Map(m =>
            {
                m.ToTable("Courses_Appointments");
                m.MapLeftKey("CourseId");
                m.MapRightKey("AppoitmentId");
            });

    */



        }
    }
}
