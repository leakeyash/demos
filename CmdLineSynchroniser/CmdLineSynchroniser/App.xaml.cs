using System.Windows;
using CmdLineSynchroniser.ViewModel;

namespace CmdLineSynchroniser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            CommandLineSynchroniser view = new CommandLineSynchroniser();
            view.DataContext = new CommandLineSynchroniserViewModel();
            view.Show();
        }
    }
}
