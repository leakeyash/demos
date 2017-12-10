using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmdLineSynchroniser.Entity;
using CmdLineSynchroniser.IService;
using CmdLineSynchroniser.Repository;
using CmdLineSynchroniser.Service;

namespace CmdLineSynchroniser.ViewModel
{
    public class CommandLineSynchroniserViewModel:ViewModelBase
    {
        private IDatabaseInfoService _databaeInfoService;
        private string _databaseGroupName;
        private string _databaseInfoGroup;
        public CommandLineSynchroniserViewModel()
        {
            _databaeInfoService = new DatabaseInfoService(new DatabaseInfoRepository(Directory.GetCurrentDirectory()+ "\\configs\\DbInfos.xml"));
        }

        public List<DatabaseInfoGroup> Groups => _databaeInfoService.GetDatabaseInfoGroups();

        public string DatabaseGroupName
        {
            get { return _databaseGroupName; }
            set { _databaseGroupName = value;OnPropertyChanged(nameof(DatabaseInfoGroup)); }
        }

        public DatabaseInfoGroup DatabaseInfoGroup => _databaeInfoService.GetDatabaseInfoGroup(_databaseGroupName);
    }
}
