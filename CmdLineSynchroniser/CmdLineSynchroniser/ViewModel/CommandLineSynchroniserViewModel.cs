using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using CmdLineSynchroniser.Command;
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
        private string _commandLineFileOutputPath;
        private string _password;
        public CommandLineSynchroniserViewModel()
        {
            _databaeInfoService = new DatabaseInfoService(new DatabaseInfoRepository(Directory.GetCurrentDirectory()+ "\\configs\\DbInfos.xml"));
        }

        public List<DatabaseInfoGroup> Groups => _databaeInfoService.GetDatabaseInfoGroups();

        public string DatabaseGroupName
        {
            get => _databaseGroupName;
            set { _databaseGroupName = value;OnPropertyChanged(nameof(DatabaseInfoGroup)); }
        }

        public DatabaseInfoGroup DatabaseInfoGroup => _databaeInfoService.GetDatabaseInfoGroup(_databaseGroupName);

        public DatabaseInfo DatabaseInfo { get; set; }

        public string DataBaseName { get; set; } = "DRMS";

        public string UserName { get; set; } = "proddbo";

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            } }

        public string EodDate { get; set; }

        public string CommandLineFileOutputPath
        {
            get => _commandLineFileOutputPath ?? @"C:\Users";
            set
            {
                _commandLineFileOutputPath = value;
                OnPropertyChanged(nameof(CommandLineFileOutputPath));
            }
        } 

        public bool IsCreateNew { get; set; }
        public bool IsOverwrite { get; set; }
        public bool IsClearAll { get; set; }

        public ICommand BrowseCommandLineFileOutputPathCommand
        {
            get
            {
                return new DeletgateCommand<string>(x =>
                {
                    CommandLineFileOutputPath = BrowseDirectory(CommandLineFileOutputPath);
                });
            }
        }

        public ICommand GenerateCommandLineTextFilesCommand
        {
            get
            {
                return new DeletgateCommand<string>(x =>
                {
                    MessageBox.Show(EodDate + DataBaseName + UserName+Password+IsClearAll+ DatabaseInfo.HostName);
                });
            }
        }
        private string BrowseDirectory(string path)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.SelectedPath = path;
                dlg.ShowNewFolderButton = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    path = dlg.SelectedPath;
                }
            }
            return path;
        }
    }
}
