using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.Storage;
using App6.Models;
using Newtonsoft.Json;

namespace App6.ViewModels
{
    internal class ToDoTasksVm : ViewModel
    {
        private ObservableCollection<ToDoTask> _tasksList = new ObservableCollection<ToDoTask>();
        private const string AppLocalFolder = "MyApp";
        private const string TasksJsonFile = "tasks_list.json";

        public ObservableCollection<ToDoTask> TasksList
        {
            get { return _tasksList; }
            set
            {
                _tasksList = value;
                OnPropertyChanged();
            }
        }

        public ToDoTasksVm()
        {
//            _tasksList.Add(new ToDoTask
//            {
//                Title = "task1",
//                Value = "Description of task1"
//            });
//            _tasksList.Add(new ToDoTask
//            {
//                Title = "task2",
//                Value = "Description of task2"
//            });
            DeserializeList();
            _tasksList.CollectionChanged += SerializeDelegate;
        }

        private void SerializeDelegate(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            SerializeList();
        }

        private async void SerializeList()
        {
            var serialized = JsonConvert.SerializeObject(_tasksList);

            var storageFolder = ApplicationData.Current.LocalFolder;
            var newFolder = await storageFolder.CreateFolderAsync(AppLocalFolder, CreationCollisionOption.OpenIfExists);
            var file = await newFolder.CreateFileAsync(TasksJsonFile, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, serialized);
        }

        private async void DeserializeList()
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var newFolder = await storageFolder.CreateFolderAsync(AppLocalFolder, CreationCollisionOption.OpenIfExists);
            var files = await newFolder.GetFilesAsync();
            var file = files.FirstOrDefault(x => x.Name == TasksJsonFile);
            if (file != null)
            {
                var serialized = await FileIO.ReadTextAsync(file);

                _tasksList.Clear();
                var toDoTasks = JsonConvert.DeserializeObject<ObservableCollection<ToDoTask>>(serialized);
                foreach (var toDoTask in toDoTasks)
                {
                    _tasksList.Add(toDoTask);
                }
            }
            
        }
    }
}