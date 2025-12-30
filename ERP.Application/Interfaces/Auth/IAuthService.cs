using ERP.Application.DTOs.Auth;

namespace ERP.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}
