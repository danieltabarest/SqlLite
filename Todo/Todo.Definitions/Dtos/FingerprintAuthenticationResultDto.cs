using NsuGo.Definition.Enums;

namespace NsuGo.Definition.Dtos
{
    public class FingerprintAuthenticationResultDto
    {
        public bool Authenticated
        {
            get;
            private set;
        }

        public string ErrorMessage
        {
            get;
            set;
        }

        public FingerprintAuthenticationResultStatus Status
        {
            get;
            set;
        }

        public FingerprintAuthenticationResultDto(bool authenticated)
        {
            Authenticated = authenticated;
        }
    }
}
