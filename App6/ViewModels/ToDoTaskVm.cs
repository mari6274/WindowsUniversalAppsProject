using App6.Models;

namespace App6.ViewModels
{
    class ToDoTaskVm : ViewModel
    {
        private readonly ToDoTask _task = new ToDoTask();

        public string Title
        {
            get { return _task.Title; }
            set
            {
                _task.Title = value;
                OnPropertyChanged();
            }
        }

        public string Value
        {
            get { return _task.Value; }
            set
            {
                _task.Value = value;
                OnPropertyChanged();
            }
        }
    }
}