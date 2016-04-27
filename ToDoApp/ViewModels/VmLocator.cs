using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App6.ViewModels
{
    class VmLocator
    {
        public static ToDoTasksVm ToDoTasksVm { get; set; } = new ToDoTasksVm();
    }
}
