using ToDoApp.Models;

namespace ToDoApp.ViewModels
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

        public string CreatedAt
        {
            get { return _task.CreatedAt; }
            set
            {
                _task.CreatedAt = value;
                OnPropertyChanged();
            }
        }
    }
}