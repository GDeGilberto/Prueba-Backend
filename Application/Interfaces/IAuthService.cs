using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario> ValidateUserAsync(string email, string contrase�a);
        string GenerateJwtToken(Usuario usuario);
    }
}