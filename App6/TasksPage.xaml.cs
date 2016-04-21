using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using App6.Models;
using App6.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App6
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TasksPage : Page
    {
        public TasksPage()
        {
            InitializeComponent();
            DataContext = VmLocator.ToDoTasksVm;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (AddTaskPage));
        }

        private void ToDoTaskItem_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var selectedItem = ((ListBox) sender).SelectedItem;
            if (selectedItem != null)
            {
                Frame.Navigate(typeof(DetailsPage), selectedItem);
            }
        }

        private void LocalSettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LocalSettingsPage));
        }
    }
}