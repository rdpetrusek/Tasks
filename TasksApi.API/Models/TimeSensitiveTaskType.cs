using GraphQL.Types;

namespace TasksApi.API.Models
{
    public class TimeSensitiveTaskType : ObjectGraphType<TimeSensitiveTask>
    {
        public TimeSensitiveTaskType()
        {
            Field(x => x.DueDate);
        }
    }
}