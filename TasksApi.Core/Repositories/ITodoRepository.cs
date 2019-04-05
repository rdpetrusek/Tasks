using System;
using System.Collections.Generic;
using TodoApi.Core.Models;

namespace TodoApi.Core.Repositories
{
    public interface ITodoRepository
    {
        Todo GetTodoById(Guid id);
        IEnumerable<Todo> GetTodos();
        IEnumerable<Todo> GetCompleteTodos();
        IEnumerable<Todo> GetTodosByName(string name);
    }
}