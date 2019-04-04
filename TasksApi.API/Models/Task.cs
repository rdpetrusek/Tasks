using System;
using System.Collections.Generic;

namespace TasksApi.API.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public Task ParentTask { get; set; }
        public List<Task> DependentTasks => new List<Task>();
    }
}