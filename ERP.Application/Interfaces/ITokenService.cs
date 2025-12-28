using ERP.Domain.Entities;

namespace ERP.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
