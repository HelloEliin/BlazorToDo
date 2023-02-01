using BlazorAppz.Data;

namespace BlazorAppz.Services
{
    public interface IUserHandler
    {
        Task<CreateUser> CreateUser(CreateUser user);
        Task<CreateUser> DeleteUser(CreateUser user);
        Task<CreateUser> GetCurrentUser();

        Task<IEnumerable<CreateUser>> GetAllUsersAsync();

        Task<CreateUser> ChangeAccess(CreateUser user);

        Task<CreateUser> EditProfile(CreateUser user);

        Task<CreateUser> Authenticate(CreateUser user);
    }
}
