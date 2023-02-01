using BlazorAppz.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace BlazorAppz.Services
{
    public class UserHandler : IUserHandler
    {

        private readonly HttpClientWrapperService _httpClientWrapper;

        public UserHandler(HttpClientWrapperService client)
        {
            _httpClientWrapper = client;
        }



        public async Task<CreateUser> CreateUser(CreateUser user)
        {
            user.Access = Access.User;
            user.Id = Guid.NewGuid();
            var path = $"User/CreateUser";
            var stringContent = JsonSerializer.Serialize(user);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            return await _httpClientWrapper.PostAsync<CreateUser>(path, data);
        }


        public async Task<CreateUser> DeleteUser(CreateUser user)
        {
            var path = $"User/DeleteUser/" + user.Id.ToString();
            var result = await _httpClientWrapper.DeleteAsync<CreateUser>(path);
            return result;
        }


        public async Task<CreateUser> GetUser(Guid id)
        {
            var path = $"User/ShowUser/" + id.ToString();
            var result = await _httpClientWrapper.Get<CreateUser>(path);
            return result;
        }


        public async Task<IEnumerable<CreateUser>> GetAllUsersAsync()
        {
            var path = $"User/GetAllUsers";
            var result = await _httpClientWrapper.Get<IEnumerable<CreateUser>>(path);
            return result;

        }


        public async Task<CreateUser> GetCurrentUser()
        {
            var path = $"User/GetCurrentUser";
            var result = await _httpClientWrapper.Get<CreateUser>(path);
            return result;

        }

        public async Task<CreateUser> EditProfile(CreateUser user)
        {

            var path = $"User/EditProfile";
            var stringContent = JsonSerializer.Serialize(user);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            return await _httpClientWrapper.PutAsync<CreateUser>(path, data);

        }


        public async Task<CreateUser> Authenticate(CreateUser user)
        {
            var path = $"User/LogIn";
            var stringContent = JsonSerializer.Serialize(user);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            return await _httpClientWrapper.PostAsync<CreateUser>(path, data);
        }

        public async Task<CreateUser> ChangeAccess(CreateUser user)
        {
            var path = $"User/ChangeAccess";
            var stringContent = JsonSerializer.Serialize(user);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            return await _httpClientWrapper.PutAsync<CreateUser>(path, data);
        }




    }
}
