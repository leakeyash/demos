using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.PostgreSQL.Data.Entities;

namespace EntityFramework.PostgreSQL.Data
{
    public class JobContext:DbContext
    {
        static JobContext()
        {
#if DEBUG
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<JobContext>());
#endif
        }
        public JobContext() : base("JobContext")
        {

        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<SubJob> SubJobs { get; set; }
    }
}
