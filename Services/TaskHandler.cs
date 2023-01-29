using BlazorAppz.Data;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using Task = BlazorAppz.Data.Task;

namespace BlazorAppz.Services
{
    public class TaskHandler : ITaskHandler
    {

        private readonly HttpClientWrapperService _httpClientWrapper;

        public TaskHandler(HttpClientWrapperService client)
        {
            _httpClientWrapper = client;
        }

        public async Task<CreateToDoList> AddTask(Data.Task task)   
        {
            task.Completed = false;
            var path = $"Task/AddTask";
            var stringContent = JsonSerializer.Serialize(task);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            return await _httpClientWrapper.PostAsync<CreateToDoList>(path, data);
        }


        //    public IEnumerable<Task> GetTasks(Guid id)
        //    {
        //        var tasks = _dbContext.Task.Where(x => x.CreateToDoListId == id);
        //        return tasks;
        //    }

        public async Task<Task> UpdateTask(Data.Task task)
        {
            var path = $"Task/UpdateTask";
            var stringContent = JsonSerializer.Serialize(task);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            return await _httpClientWrapper.PutAsync<Task>(path, data);

        }

        public async Task<Task> DeleteTask(Data.Task task)   //Funkar
        {
            var path = $"Task/DeleteTask/" + task.Id.ToString();
            return await _httpClientWrapper.DeleteAsync<Task>(path);
        }


        public async Task<Task> GetSingelTask(Guid id)
        {
            var path = $"Task/GetSingleTask/" + id.ToString(); 
            return await _httpClientWrapper.Get<Task>(path);

        }


        public async Task<Task> MarkAsComplete(Data.Task task)
        {
            var path = $"Task/Completed";
            var stringContent = JsonSerializer.Serialize(task);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            var result = await _httpClientWrapper.PutAsync<Task>(path, data);
            return result;
        }




    }

}



