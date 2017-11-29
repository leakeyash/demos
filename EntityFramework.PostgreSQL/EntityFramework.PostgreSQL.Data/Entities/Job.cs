using System.Collections.Generic;

namespace EntityFramework.PostgreSQL.Data.Entities
{
    public class Job
    {
        public int ID { get; set; }

        public int? RunInfoID { get; set; }

        public ICollection<SubJob> SubJobs { get; set; }
    }
}
