using WebApi.DTO;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IAuthService
    {
        string GenerateTokenString(LoginDto user);
        Task<bool> Login(LoginDto user);
        Task<bool> Register(LoginDto user);
    }
}