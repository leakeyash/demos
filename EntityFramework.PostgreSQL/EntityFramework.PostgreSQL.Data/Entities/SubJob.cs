namespace EntityFramework.PostgreSQL.Data.Entities
{
    public class SubJob
    {
        public int ID { get; set; }

        public int? RunInfoID { get; set; }

        public int JobId { get; set; }

        public virtual Job Job { get; set; }
    }
}
