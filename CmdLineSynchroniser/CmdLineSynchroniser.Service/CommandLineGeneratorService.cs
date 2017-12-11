using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CmdLineSynchroniser.IRepository;
using CmdLineSynchroniser.IRepository.DTOs;
using CmdLineSynchroniser.IService;
using CmdLineSynchroniser.IService.DTOs;
using CmdLineSynchroniser.Repository;

namespace CmdLineSynchroniser.Service
{
    public class CommandLineGeneratorService:ICommandLineGeneratorService
    {
        public IJobDetailRepository JobDetailRepository { get; set; }
        
        public int GenerateCommandLineTextFile(SybaseInfo sybaseInfo, string outputPath, string sqlXmlPath,string eodDate, FileHanlder fileHanlder)
        {
            string connectionString =
                $"Data Source={sybaseInfo.ServerName};Port={sybaseInfo.Port};Initial Catalog={sybaseInfo.DatabaseName};UID={sybaseInfo.UserName};PWD={sybaseInfo.Password};Connection Timeout=120;Command Timeout=120;";
            JobDetailRepository = new JobDetailRepository(connectionString);

            var jobDetailsTable = new DataTable();
            var jobDetailSet = GetJobDetails(sqlXmlPath, eodDate, JobDetailRepository);           
            foreach (DataTable table in jobDetailSet.Tables)
            {
                jobDetailsTable.Merge(table);
            }
            
            return 0;

        }

        private static DataSet GetJobDetails(string sqlsPath, string eodDate,IJobDetailRepository jobDetailRepository)
        {
            var xdoc = XDocument.Load(sqlsPath);
            var result = from item in xdoc.Element("sqls")?.Elements("category")
                select new
                {
                    Category = item.Attribute("Name")?.Value,
                    Sqls = (from sql in item.Elements("sql")
                        select new
                        {
                            Priority = sql.Attribute("priority")?.Value,
                            Description = sql.Attribute("description")?.Value,
                            SqlStatement = sql.Value
                        }).OrderBy(x => x.Priority).ToList()
                };
            DataSet dataSet = new DataSet();
            foreach (var category in result)
            {
                DataTable jobDeatils = new DataTable(category.Category);
                foreach (var sql in category.Sqls)
                {
                    var table = jobDetailRepository.GetJobDetail(sql.SqlStatement.Replace("{eodDate}", eodDate), category.Category);
                    
                    if (table.Rows.Count != 0)
                    {
                        break;
                    }
                }
                dataSet.Tables.Add(jobDeatils);
            }
            return dataSet;
        }
    }
}
