using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App6.Models;

namespace App6.ViewModels
{
    class ToDoTasksVm : ViewModel
    {
        private ObservableCollection<ToDoTask> _tasksList = new ObservableCollection<ToDoTask>();

        public ToDoTasksVm()
        {
            _tasksList.Add(new ToDoTask()
            {
                Title = "task1",
                Value = "Description of task1"
            });
            _tasksList.Add(new ToDoTask()
            {
                Title = "task2",
                Value = "Description of task2"
            });
        }

        public ObservableCollection<ToDoTask> TasksList
        {
            get
            {
                return _tasksList;
            }
            set
            {
                _tasksList = value;
                OnPropertyChanged();
            }
        }
    }
}
