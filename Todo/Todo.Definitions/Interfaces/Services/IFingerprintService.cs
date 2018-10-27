using System.Threading;
using System.Threading.Tasks;
using NsuGo.Definition.Dtos;
using NsuGo.Definition.Enums;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface IFingerprintService
    {
        Task<FingerprintAvailability> GetAvailabilityAsync(bool allowAlternativeAuthentication = false);

        Task<bool> IsAvailableAsync(bool allowAlternativeAuthentication = false);

        Task<FingerprintAuthenticationResultDto> AuthenticateAsync(string reason, CancellationToken cancellationToken = default(CancellationToken));

        Task<FingerprintAuthenticationResultDto> AuthenticateAsync(AuthenticationRequestConfigurationDto authRequestConfig, CancellationToken cancellationToken = default(CancellationToken));
    }
}
