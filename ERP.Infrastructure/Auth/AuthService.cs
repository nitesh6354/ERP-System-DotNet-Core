using ERP.Application.DTOs.Auth;
using ERP.Application.Interfaces.Auth;
using ERP.Domain.Entities;
using ERP.Infrastructure.Data;
using ERP.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenService _tokenService;

        public AuthService(ApplicationDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            // 1️⃣ Find user
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username && u.IsActive);

            if (user == null)
                throw new Exception("Invalid username or password");

            // 2️⃣ Verify hashed password
            var isValidPassword = PasswordHasher.VerifyPassword(
                request.Password,
                user.PasswordHash
            );

            if (!isValidPassword)
                throw new Exception("Invalid username or password");

            // 3️⃣ Generate JWT token
            var token = _tokenService.GenerateToken(
                user.Id,
                user.Username,
                user.Role
            );

            return new LoginResponseDto
            {
                Token = token,
                Username = user.Username,
                Role = user.Role
            };
        }
    }
}
