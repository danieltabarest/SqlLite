

using Todo.Common.Helpers;

namespace NsuGo.Definition.Utilities
{
    public static class FingerprintHelpers
    {
        
        public static string FingerprintAuthenticationName => UserSettings.FingerprintAuthenticationName;

        public static string FingerprintAuthenticationProvider => UserSettings.FingerprintAuthenticationProvider;

        public static bool IsFingerprintAuthenticationSetupRequired => UserSettings.ShouldSetupFingerprintAuthentication &&
                                                                       !UserSettings.IsFingerprintAuthenticationEnabled;

        public static bool IsFingerprintAuthenticationEnabled => UserSettings.IsFingerprintAuthenticationEnabled;

        public static bool IsFingerprintAuthenticationAccepted => UserSettings.IsFingerprintAuthenticationAccepted;


		public static void AcceptFingerprintAuthentication()
		{
            UserSettings.IsFingerprintAuthenticationAccepted = true;
		}

        public static void MakeFingerprintAuthenticationSetupRequired()
        {
            UserSettings.ShouldSetupFingerprintAuthentication = true;
        }

        public static void RemoveFingerprintAuthenticationSetupRequirement()
        {
            UserSettings.ShouldSetupFingerprintAuthentication = false;
        }

		public static void TurnOnFingerprintAuthentication()
		{
            if (UserSettings.ShouldSetupFingerprintAuthentication)
                UserSettings.ShouldSetupFingerprintAuthentication = false;

            UserSettings.IsFingerprintAuthenticationEnabled = true;
		}

        public static void TurnOffFingerprintAuthentication()
		{
            UserSettings.IsFingerprintAuthenticationEnabled = false;
		}
    }
}
