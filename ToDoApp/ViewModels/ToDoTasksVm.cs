using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    internal class ToDoTasksVm : ViewModel
    {
        private const string AppLocalFolder = "MyApp";
        private const string TasksJsonFile = "tasks_list.json";
        private static readonly string TASK_RESOURCE_URL = "http://windowsphoneuam.azurewebsites.net/api/ToDoTasks";
        private ObservableCollection<ToDoTask> _tasksList = new ObservableCollection<ToDoTask>();

        public ToDoTasksVm()
        {
            GetTasks();
        }

        public ObservableCollection<ToDoTask> TasksList
        {
            get { return _tasksList; }
            set
            {
                _tasksList = value;
                OnPropertyChanged();
            }
        }

        private async Task<ToDoTask> PostTask(ToDoTask task)
        {
            var client = new HttpClient();
            var serialized = JsonConvert.SerializeObject(task);
            var response = await client.PostAsync(TASK_RESOURCE_URL, new StringContent(serialized, Encoding.UTF8, "application/json"));
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ToDoTask>(content);
        }

        public async void GetTasks()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(TASK_RESOURCE_URL);
            var content = await response.Content.ReadAsStringAsync();
            var toDoTasks = JsonConvert.DeserializeObject<List<ToDoTask>>(content);

            _tasksList.Clear();
            foreach (var toDoTask in toDoTasks)
            {
                _tasksList.Add(toDoTask);
            }
        }

        public void Add(ToDoTask toDoTask)
        {
            Task<ToDoTask> returnedTask = PostTask(toDoTask);
            returnedTask.GetAwaiter().OnCompleted(() => TasksList.Add(returnedTask.Result));
        }

        public void Remove(ToDoTask toDoTask)
        {
            TasksList.Remove(toDoTask);
            DeleteTask(toDoTask);
        }

        private async void DeleteTask(ToDoTask toDoTask)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync(TASK_RESOURCE_URL + "/" + toDoTask.Id);
        }

        public void Edit(ToDoTask toDoTask)
        {
            PutTask(toDoTask);
        }

        private async void PutTask(ToDoTask toDoTask)
        {
            var client = new HttpClient();
            var serialized = JsonConvert.SerializeObject(toDoTask);
            await client.PutAsync(TASK_RESOURCE_URL + "/" + toDoTask.Id, new StringContent(serialized, Encoding.UTF8, "application/json"));
        }
    }
}