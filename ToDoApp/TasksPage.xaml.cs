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
        private readonly ToDoTasksVm _toDoTasksVm;

        public TasksPage()
        {
            InitializeComponent();
            _toDoTasksVm = VmLocator.ToDoTasksVm;
            _toDoTasksVm.GetUserTasks();
            DataContext = _toDoTasksVm;
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

        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            _toDoTasksVm.GetUserTasks();
        }

        private void ContactButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ContactPage));
        }

        private void ChangeUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}