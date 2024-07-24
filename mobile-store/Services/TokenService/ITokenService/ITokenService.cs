using mobile_store.Models;

namespace mobile_store.Services.TokenService
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
