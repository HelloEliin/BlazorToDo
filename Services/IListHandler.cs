using BlazorAppz.Data;
using Task = System.Threading.Tasks.Task;

namespace BlazorAppz.Services
{
    public interface IListHandler 
    {
        Task <CreateToDoList> CreateNewToDoList(CreateToDoList list);
        Task <CreateToDoList> GetRecentViewedList();
        Task<IEnumerable<CreateToDoList>> GetAllListsAsync();
        Task<CreateToDoList> DeleteList(CreateToDoList list);
        Task<CreateToDoList> UpdateList(CreateToDoList list);
        Task<CreateToDoList> ShowList(Guid id);
        //CreateToDoList WeeklyList(Guid? id);
        Task<IEnumerable<CreateToDoList>> GetCurrentUserListsAsync();
    }
}
