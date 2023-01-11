using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRespository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetuserByidAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDto>> GetMemberAsync();
        Task<MemberDto> GetMemberAsync(string username);
    }
}