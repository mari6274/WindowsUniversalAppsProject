using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    internal class ToDoTasksVm : ViewModel
    {
        private const string AppLocalFolder = "MyApp";
        private const string TasksJsonFile = "tasks_list.json";
        private readonly RestClient _restClient = new RestClient();
        private ObservableCollection<ToDoTask> _tasksList = new ObservableCollection<ToDoTask>();

        public ObservableCollection<ToDoTask> TasksList
        {
            get { return _tasksList; }
            set
            {
                _tasksList = value;
                OnPropertyChanged();
            }
        }

        private void RefreshCurrentUserTasks(List<ToDoTask> toDoTasks)
        {
            var currentUserName = VmLocator.UserNameVm.UserName;
            _tasksList.Clear();
            toDoTasks.Where(task => task.OwnerId == currentUserName).ToList().ForEach(_tasksList.Add);
        }

        public void Add(ToDoTask toDoTask)
        {
            var returnedTask = _restClient.PostTask(toDoTask);
            returnedTask.GetAwaiter().OnCompleted(() => TasksList.Add(returnedTask.Result));
        }

        public void Remove(ToDoTask toDoTask)
        {
            TasksList.Remove(toDoTask);
            _restClient.DeleteTask(toDoTask);
        }


        public void Edit(ToDoTask toDoTask)
        {
            _restClient.PutTask(toDoTask);
        }

        public async void RefreshTasks()
        {
            var result = await _restClient.GetUserTasks();
            RefreshCurrentUserTasks(result);
        }
    }
}