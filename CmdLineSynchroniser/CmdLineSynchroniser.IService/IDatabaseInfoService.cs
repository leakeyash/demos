using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmdLineSynchroniser.Entity;

namespace CmdLineSynchroniser.IService
{
    public interface IDatabaseInfoService
    {
        List<DatabaseInfoGroup> GetDatabaseInfoGroups();

        DatabaseInfoGroup GetDatabaseInfoGroup(string groupName);

        List<string> GetGroupNames();
    }
}
