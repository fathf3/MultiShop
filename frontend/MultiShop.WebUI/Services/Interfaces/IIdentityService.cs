using MultiShop.DtoLayer.Dtos.IdentityDtos.LoginDtos;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SingInDto dto);
        Task<bool> GetRefreshToken();
    }
}
