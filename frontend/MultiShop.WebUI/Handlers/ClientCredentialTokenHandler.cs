
using MultiShop.WebUI.Services.Interfaces;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Handlers
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly IClientCredentialTokenService _clientCredentialTokanService;

        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokanService)
        {
            _clientCredentialTokanService = clientCredentialTokanService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _clientCredentialTokanService.GetToken());

            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            { // Hata }
                
            }
            return response;
        }
    }
}
