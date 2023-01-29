using BlazorAppz.Data;
using Task = BlazorAppz.Data.Task;

namespace BlazorAppz.Services
{
    public interface ITaskHandler
    {
        Task<CreateToDoList> AddTask(Task task);
        //IEnumerable<Task> GetTasks(Guid id);
        Task<Task> UpdateTask(Task task);
        Task<Task> GetSingelTask(Guid id);

        //Task MarkAsComplete(bool completed);
        //CreateToDoList CreateNewToDoList(string listTitle);
        //IEnumerable<CreateToDoList> GetLists();
        Task<Task> DeleteTask(Task task);
        //CreateToDoList ChangeTaskName(int id, string value);
    }
}
