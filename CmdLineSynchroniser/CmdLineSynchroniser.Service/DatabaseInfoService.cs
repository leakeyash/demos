using System.Collections.Generic;
using System.Linq;
using CmdLineSynchroniser.Entity;
using CmdLineSynchroniser.IRepository;
using CmdLineSynchroniser.IService;

namespace CmdLineSynchroniser.Service
{
    public class DatabaseInfoService:IDatabaseInfoService
    {
        private readonly IDatabaseInfoRepository _databaseInfoRepository;
        public DatabaseInfoService(IDatabaseInfoRepository databaseInfoRepository)
        {
            _databaseInfoRepository = databaseInfoRepository;
        }
        public List<DatabaseInfoGroup> GetDatabaseInfoGroups()
        {
            return _databaseInfoRepository.GetList().ToList();
        }

        public DatabaseInfoGroup GetDatabaseInfoGroup(string groupName)
        {
            return _databaseInfoRepository.Get(x => x.Name == groupName);
        }

        public List<string> GetGroupNames()
        {
            var groupNames= _databaseInfoRepository.GetList().Select(databaseInfo => databaseInfo.Name).Distinct().ToList();
            return groupNames;
        }
    }
}
