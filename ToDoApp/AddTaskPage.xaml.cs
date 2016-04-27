using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using App6.Models;
using App6.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App6
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddTaskPage : Page
    {
        public AddTaskPage()
        {
            InitializeComponent();
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            VmLocator.ToDoTasksVm.Add((ToDoTask) DataContext);
            Frame.GoBack();
        }
    }
}