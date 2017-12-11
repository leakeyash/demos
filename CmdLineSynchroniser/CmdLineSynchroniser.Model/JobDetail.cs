using System;

namespace CmdLineSynchroniser.Entity
{
    public class JobDetail
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int EodDate { get; set; }
        public string JobName { get; set; }
        public string Catagory { get; set; }
        public DateTime AppStartTime { get; set; }
        public DateTime AppEndTime { get; set; }
        public int ExitCode { get; set; }
        public string Comments { get; set; }
        public string CommandLine { get; set; }
    }
}
