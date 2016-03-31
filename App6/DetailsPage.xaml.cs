using System;
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
        private ToDoTask _toDoTask;
        private readonly ToDoTask _task;

        public DetailsPage()
        {
            InitializeComponent();
            _task = (ToDoTask) DataContext;
        }

        private void Accept_OnClick(object sender, RoutedEventArgs e)
        {
            var task = _task as ToDoTask;
            _toDoTask.Title = task.Title;
            _toDoTask.Value = task.Value;
            Frame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _toDoTask = (ToDoTask) e.Parameter;
            _task.Title = _toDoTask.Title;
            _task.Value = _toDoTask.Value;
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            EnableEditMode();
        }

        private void EnableEditMode()
        {
            AcceptButton.Visibility = Visibility.Visible;
            CancelButton.Visibility = Visibility.Visible;
            EditButton.Visibility = Visibility.Collapsed;
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            VmLocator.ToDoTasksVm.TasksList.Remove(_toDoTask);
            Frame.GoBack();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            DisableEditMode();

        }

        private void DisableEditMode()
        {
            AcceptButton.Visibility = Visibility.Visible;
            CancelButton.Visibility = Visibility.Visible;
            EditButton.Visibility = Visibility.Collapsed;
        }
    }
}