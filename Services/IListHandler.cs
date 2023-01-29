using BlazorAppz.Data;
using Task = System.Threading.Tasks.Task;

namespace BlazorAppz.Services
{
    public interface IListHandler 
    {
        Task <CreateToDoList> CreateNewToDoList(CreateToDoList list);
        Task <Guid> GetRecentViewedList();
        Task<IEnumerable<CreateToDoList>> GetAllListsAsync();
        Task<CreateToDoList> DeleteList(CreateToDoList list);
        Task<CreateToDoList> EditList(CreateToDoList list);
        Task<CreateToDoList> ShowList(Guid id);
        //CreateToDoList WeeklyList(Guid? id);
        Task<IEnumerable<CreateToDoList>> GetCurrentUserListsAsync();
    }
}
