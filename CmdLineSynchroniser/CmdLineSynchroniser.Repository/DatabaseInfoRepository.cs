using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CmdLineSynchroniser.Entity;
using CmdLineSynchroniser.IRepository;

namespace CmdLineSynchroniser.Repository
{
    public class DatabaseInfoRepository : ListRepository<DatabaseInfoGroup>, IDatabaseInfoRepository
    {
        public DatabaseInfoRepository(string configPath)
        {
            if (!File.Exists(configPath)) return;

            var xdoc = XDocument.Load(configPath);
            var result = from item in xdoc.Element("Databases")?.Elements()
                select new DatabaseInfoGroup()
                {
                    Name = item.Attribute("Name")?.Value,
                    Infos = (from dbinfo in item.Elements("Database")
                        let port = dbinfo.Element("Port")
                        let dbName = dbinfo.Element("Name")
                        let hostName = dbinfo.Element("HostName")
                        where port != null && dbName != null && port != null
                        select new DatabaseInfo()
                        {
                            Name = dbName.Value,
                            HostName = hostName.Value,
                            Port = int.Parse(port.Value)
                        }).ToList()
                };
            Entities = result.ToList();
        }
    }
}
