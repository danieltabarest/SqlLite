using System.Threading;
using System.Threading.Tasks;
using NsuGo.Definition.Dtos;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Interfaces.Services;

namespace NsuGo.ServiceAccess.Services
{
    public class FingerprintService : IFingerprintService
    {
        public Task<FingerprintAuthenticationResultDto> AuthenticateAsync(string reason, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public Task<FingerprintAuthenticationResultDto> AuthenticateAsync(AuthenticationRequestConfigurationDto authRequestConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public Task<FingerprintAvailability> GetAvailabilityAsync(bool allowAlternativeAuthentication = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsAvailableAsync(bool allowAlternativeAuthentication = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
