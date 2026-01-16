using MultiShop.WebUI.Services.Interfaces;
using System.Security.Claims;

namespace MultiShop.WebUI.Services.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAcccessor;

        public LoginService(IHttpContextAccessor contextAcccessor)
        {
            _contextAcccessor = contextAcccessor;
        }

        public string GetUserId => _contextAcccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
