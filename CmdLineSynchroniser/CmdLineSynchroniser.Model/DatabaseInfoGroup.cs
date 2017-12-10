using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdLineSynchroniser.Entity
{
    public class DatabaseInfoGroup
    {
        public string Name { get; set; }
        public IList<DatabaseInfo> Infos { get; set; } 
    }
}
