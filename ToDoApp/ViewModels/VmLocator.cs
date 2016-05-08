namespace ToDoApp.ViewModels
{
    class VmLocator
    {
        public static ToDoTasksVm ToDoTasksVm { get; set; } = new ToDoTasksVm();
        public static UserNameVm UserNameVm { get; set; } = new UserNameVm();
    }
}
