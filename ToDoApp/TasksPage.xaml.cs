using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using ToDoApp.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ToDoApp
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
            Frame.Navigate(typeof (ToDoApp.AddTaskPage));
        }

        private void ToDoTaskItem_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var selectedItem = ((ListBox) sender).SelectedItem;
            if (selectedItem != null)
            {
                Frame.Navigate(typeof(ToDoApp.DetailsPage), selectedItem);
            }
        }

        private void LocalSettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ToDoApp.LocalSettingsPage));
        }

        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            VmLocator.ToDoTasksVm.GetTasks();
        }

        private void ContactButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ToDoApp.ContactPage));
        }
    }
}