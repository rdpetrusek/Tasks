using System;

namespace TasksApi.API.Models
{
    public class TimeSensitiveTask : Task
    {
        public DateTime DueDate { get; set; }
    }
}