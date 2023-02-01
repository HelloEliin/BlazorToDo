using BlazorAppz.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;
using System.Text.Json;
using Task = BlazorAppz.Data.Task;

namespace BlazorAppz.Services
{
    public class ListHandler : IListHandler
    {
        private readonly HttpClientWrapperService _httpClientWrapper;

        public ListHandler(HttpClientWrapperService client)
        {
            _httpClientWrapper = client;
        }

        public async Task<IEnumerable<CreateToDoList>> GetCurrentUserListsAsync()  //Funkar
        {
            var path = "List/GetCurrentUsersLists";
            var result = await _httpClientWrapper.Get<IEnumerable<CreateToDoList>>(path);

            return result;
        }


        public async Task<CreateToDoList> CreateNewToDoList(CreateToDoList list)   //funkar
        {
            list.ThisWeek = false;
            list.Expired = false;
            list.Date = DateTime.Now.ToString("G");
            list.Id= Guid.NewGuid();

            list.Task = new List<Task>();
            var path = $"List/CreateNewToDoList";
            var stringContent = JsonSerializer.Serialize(list);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            return await _httpClientWrapper.PostAsync<CreateToDoList>(path, data);

        }

        public async Task<CreateToDoList> GetRecentViewedList()  //funakr
        {
            var path = $"List/ViewSingleList";
            return await _httpClientWrapper.Get<CreateToDoList>(path);

        }

        public async Task<IEnumerable<CreateToDoList>> GetAllListsAsync()   //Funkar
        {
            var path = $"List/GetAllLists";
            var result = await _httpClientWrapper.Get<IEnumerable<CreateToDoList>>(path);
            return result;

        }

        public async Task<CreateToDoList> DeleteList(CreateToDoList list)   //Funkar
        {
            var path = $"List/DeleteList/" + list.Id.ToString();
            return await _httpClientWrapper.DeleteAsync<CreateToDoList>(path);
        }

        public async Task<CreateToDoList> UpdateList(CreateToDoList list)
        {
            var path = $"List/EditList";
            var stringContent = JsonSerializer.Serialize(list);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            var result = await _httpClientWrapper.PutAsync<CreateToDoList>(path, data);
            return result;

        }

        public async Task<CreateToDoList> ShowList(Guid id)   //Funkar
        {
            var path = $"List/ShowList/"+id.ToString();
            var result = await _httpClientWrapper.Get<CreateToDoList>(path);
            return result;
        }

            //public CreateToDoList WeeklyList(Guid? id)
            //{
            //    if(id == null)
            //    {
            //        id = Guid.Parse(ListDictionary.id["ListId"]);
            //    }
            //    var list = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
            //    list.ThisWeek = true;
            //    _dbContext.SaveChanges();
            //    return list;
            //}




    }
}
