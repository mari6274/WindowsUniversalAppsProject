using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using App6.Models;
using App6.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App6
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsPage : Page
    {
        private readonly ToDoTaskVm _taskVm;
        private ToDoTask _toDoTask;

        public DetailsPage()
        {
            InitializeComponent();
            _taskVm = (ToDoTaskVm) DataContext;
        }

        private void Accept_OnClick(object sender, RoutedEventArgs e)
        {
            CopyTask(_toDoTask, _taskVm);
            VmLocator.ToDoTasksVm.Edit(_toDoTask);
            Frame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _toDoTask = (ToDoTask) e.Parameter;
            CopyTask(_taskVm, _toDoTask);
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            EnableEditMode();
        }

        private void EnableEditMode()
        {
            TitleTextBlock.Visibility = Visibility.Collapsed;
            TitleTextBox.Visibility = Visibility.Visible;
            ValueTextBlock.Visibility = Visibility.Collapsed;
            ValueTextBox.Visibility = Visibility.Visible;

            AcceptButton.Visibility = Visibility.Visible;
            CancelButton.Visibility = Visibility.Visible;
            EditButton.Visibility = Visibility.Collapsed;
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            VmLocator.ToDoTasksVm.Remove(_toDoTask);
            Frame.GoBack();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            CopyTask(_taskVm, _toDoTask);
            DisableEditMode();
        }

        private void CopyTask(ToDoTask to, ToDoTaskVm from)
        {
            to.Title = from.Title;
            to.Value = from.Value;
        }

        private void CopyTask(ToDoTaskVm to, ToDoTask from)
        {
            to.Title = from.Title;
            to.Value = from.Value;
        }

        private void DisableEditMode()
        {
            TitleTextBlock.Visibility = Visibility.Visible;
            TitleTextBox.Visibility = Visibility.Collapsed;
            ValueTextBlock.Visibility = Visibility.Visible;
            ValueTextBox.Visibility = Visibility.Collapsed;

            AcceptButton.Visibility = Visibility.Collapsed;
            CancelButton.Visibility = Visibility.Collapsed;
            EditButton.Visibility = Visibility.Visible;
        }
    }
}