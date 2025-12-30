using ERP.Application.DTOs.Auth;
using ERP.Application.Interfaces.Auth;
using ERP.Domain.Entities;

namespace ERP.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            // TEMP mock user (later DB)
            var user = new User
            {
                Id = 1,
                Username = request.Username,
                Role = "Admin"
            };

            var token = "TEMP_JWT_TOKEN";

            return new LoginResponseDto
            {
                UserId = user.Id,
                Username = user.Username,
                Role = user.Role,
                Token = token
            };
        }
    }
}
