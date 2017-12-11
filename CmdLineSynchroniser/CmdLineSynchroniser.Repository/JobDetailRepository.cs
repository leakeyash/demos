using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmdLineSynchroniser.IRepository;
using Sybase.Data.AseClient;

namespace CmdLineSynchroniser.Repository
{
    public class JobDetailRepository:IJobDetailRepository
    {
        private readonly AseConnection _aseConnection;
        public JobDetailRepository(string connectionString)
        {
            _aseConnection=new AseConnection(connectionString);
        }
        public DataTable GetJobDetail(string sqlCommand,string tableName)
        {
            DataTable dt=new DataTable(tableName);
            var cmd=new AseCommand(sqlCommand,_aseConnection);
            var ada=new AseDataAdapter(cmd);
            ada.Fill(dt);
            return dt;
        }
    }
}
