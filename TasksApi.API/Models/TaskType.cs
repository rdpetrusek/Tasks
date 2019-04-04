using GraphQL.Types;

namespace TasksApi.API.Models
{
    public class TaskType : ObjectGraphType<Task>
    {
        public TaskType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Name);
            Field(x => x.IsComplete);
        }
    }
}