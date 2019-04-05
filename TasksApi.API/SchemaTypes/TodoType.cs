using GraphQL.Types;
using TodoApi.Core.Models;

namespace TodoApi.API.SchemaTypes
{
    public class TodoType : ObjectGraphType<Todo>
    {
        public TodoType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Name);
            Field(x => x.IsComplete);
            Field(x => x.ParentTodo, type: typeof(TodoType));
        }
    }
}