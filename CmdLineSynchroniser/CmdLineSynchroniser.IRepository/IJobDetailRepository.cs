using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdLineSynchroniser.IRepository
{
    public interface IJobDetailRepository
    {
        DataTable GetJobDetail(string sqlCommand,string tableName);
    }
}
