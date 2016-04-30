﻿namespace ToDoApp.Models
{
    public class ToDoTask
    {
        public string Id { get; set; } = "0";
        public string Title { get; set; }
        public string Value { get; set; }
        public string OwnerId { get; set; } = "";
        public string CreatedAt { get; set; } = "";
    }
}