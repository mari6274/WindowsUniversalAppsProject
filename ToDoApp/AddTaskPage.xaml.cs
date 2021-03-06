﻿using System;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ToDoApp.Models;
using ToDoApp.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDoApp
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddTaskPage : Page
    {
        private readonly ToDoTask _toDoTask;

        public AddTaskPage()
        {
            InitializeComponent();
            _toDoTask = new ToDoTask()
            {
                Id = "0",
                Title = "",
                Value = "",
                OwnerId = "",
                CreatedAt = ""
            };
            DataContext = _toDoTask;;
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            if (TitleTextBox.Valid)
            {
                _toDoTask.CreatedAt = String.Format("dd-MM-yy HH:mm:ss", DateTime.Now.ToString(CultureInfo.CurrentCulture));
                _toDoTask.OwnerId = VmLocator.UserNameVm.UserName;
                VmLocator.ToDoTasksVm.Add(_toDoTask);
                Frame.GoBack();
            }
        }
    }
}