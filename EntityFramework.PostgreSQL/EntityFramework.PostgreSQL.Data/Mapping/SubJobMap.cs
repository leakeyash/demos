using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.PostgreSQL.Data.Entities;

namespace EntityFramework.PostgreSQL.Data.Mapping
{
    public class SubJobMap:EntityTypeConfiguration<SubJob>
    {
        public SubJobMap()
        {
            //Primary Key
            HasKey(t => t.ID);

            //Properties
            Property(t => t.RunInfoID);
           

            // Table & Column Mappings
            ToTable("sub_job");
            Property(t => t.RunInfoID).HasColumnName("runinfo_id");
            Property(t => t.ID).HasColumnName("id");

            //Relationships
            HasRequired(t => t.Job).WithMany(t => t.SubJobs).HasForeignKey(d => d.JobId);
        }
    }
}
