﻿using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using ToDoApp.ViewModels;

namespace ToDoApp.Models
{
    public class ToDoTask
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string OwnerId { get; set; }
        public string CreatedAt { get; set; }
    }
}
