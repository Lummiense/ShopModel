using System.Threading.Tasks;
using ShopApi.Model;

namespace ShopApi.Service
{
    public interface IUserService
    {
        Task<LoginResponse> Authentication(LoginRequest request);
        Task Registration(RegisterRequest request);
    }
}
