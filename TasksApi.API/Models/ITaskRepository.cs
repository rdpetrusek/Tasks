using System;
using System.Collections.Generic;

namespace TasksApi.API.Models
{
    public interface ITaskRepository
    {
        Task GetTaskById(Guid id);
        IEnumerable<Task> GetTasks();
        IEnumerable<Task> GetCompleteTasks();
        IEnumerable<Task> GetTasksByName(string name);
    }
}