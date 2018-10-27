using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Todo.Common.Helpers
{
    public static class UserSettings
    {
        private static readonly string DefaultString = string.Empty;

        private const string UsernameKey = "username_key";

        private const string IsFirstTimeKey = "first_time_key";

        private const string AccessTokenKey = "access_token_key";

        private const string RefreshTokenKey = "refresh_token_key";

        private const string TokenExpiryDateTimeKey = "token_expiry_date_time_key";

        private const string IsUsernameSavedKey = "username_saved_key";

        private const string FingerprintAuthenticationAcceptanceKey = "fingerprint_authentication_accepted_key";

        private const string FingerprintAuthenticationEnabledKey = "fingerprint_authentication_enabled_key";

        private const string SetupFingerprintAuthenticationKey = "setup_fingerprint_authentication_key";

        private const string FingerprintAuthenticationNameKey = "fingerprint_authentication_name_key";

        private const string FingerprintAuthenticationProviderKey = "fingerprint_authentication_provider_key";

        private const string ShouldPurgeLocalStorageKey = "purge_local_storage_key";

        private const string LastLoginKey = "last_login_key";

        private const string LastCriticalDataUpdateKey = "last_critical_data_update_key";

        private const string LastDataUpdateKey = "last_data_update_key";

        private const string IsFirstTimeOnDashboardKey = "first_time_on_dashboard_key";

        private const string IsFirstTimeOnProfileKey = "first_time_on_profile_key";

        private const string IsFirstTimeOnCourseContentKey = "first_time_on_course_content_key";

        private const string IsFirstTimeOnCourseAssignmentsKey = "first_time_on_course_assignments_key";


        private static ISettings AppSettings => CrossSettings.Current;


        public static string Username
        {
            get => AppSettings.GetValueOrDefault(UsernameKey, DefaultString);

            set => AppSettings.AddOrUpdateValue(UsernameKey, value);
        }

        public static bool IsFirstTime
        {
            get => AppSettings.GetValueOrDefault(IsFirstTimeKey, true);

            set => AppSettings.AddOrUpdateValue(IsFirstTimeKey, value);
        }

        public static bool IsFirstTimeOnDashboard
        {
            get => AppSettings.GetValueOrDefault(IsFirstTimeOnDashboardKey, true);

            set => AppSettings.AddOrUpdateValue(IsFirstTimeOnDashboardKey, value);
        }

        public static bool IsFirstTimeOnProfile
        {
            get => AppSettings.GetValueOrDefault(IsFirstTimeOnProfileKey, true);

            set => AppSettings.AddOrUpdateValue(IsFirstTimeOnProfileKey, value);
        }

        public static bool IsFirstTimeOnCourseContent
        {
            get => AppSettings.GetValueOrDefault(IsFirstTimeOnCourseContentKey, true);

            set => AppSettings.AddOrUpdateValue(IsFirstTimeOnCourseContentKey, value);
        }

        public static bool IsFirstTimeOnCourseAssignments
        {
            get => AppSettings.GetValueOrDefault(IsFirstTimeOnCourseAssignmentsKey, true);

            set => AppSettings.AddOrUpdateValue(IsFirstTimeOnCourseAssignmentsKey, value);
        }

        public static string AccessToken
        {
            get => AppSettings.GetValueOrDefault(AccessTokenKey, DefaultString);

            set => AppSettings.AddOrUpdateValue(AccessTokenKey, value);
        }

        public static string RefreshToken
        {
            get => AppSettings.GetValueOrDefault(RefreshTokenKey, DefaultString);

            set => AppSettings.AddOrUpdateValue(RefreshTokenKey, value);
        }

        public static string TokenExpiryDateTime
        {
            get => AppSettings.GetValueOrDefault(TokenExpiryDateTimeKey, DefaultString);

            set => AppSettings.AddOrUpdateValue(TokenExpiryDateTimeKey, value);
        }

        public static bool IsUsernameSaved
        {
            get => AppSettings.GetValueOrDefault(IsUsernameSavedKey, false);

            set => AppSettings.AddOrUpdateValue(IsUsernameSavedKey, value);
        }

        public static bool IsFingerprintAuthenticationAccepted
        {
            get => AppSettings.GetValueOrDefault(FingerprintAuthenticationAcceptanceKey, false);

            set => AppSettings.AddOrUpdateValue(FingerprintAuthenticationAcceptanceKey, value);
        }

        public static bool IsFingerprintAuthenticationEnabled
        {
            get => AppSettings.GetValueOrDefault(FingerprintAuthenticationEnabledKey, false);

            set => AppSettings.AddOrUpdateValue(FingerprintAuthenticationEnabledKey, value);
        }

        public static bool ShouldSetupFingerprintAuthentication
        {
            get => AppSettings.GetValueOrDefault(SetupFingerprintAuthenticationKey, false);

            set => AppSettings.AddOrUpdateValue(SetupFingerprintAuthenticationKey, value);
        }

        public static string FingerprintAuthenticationName
        {
            get => AppSettings.GetValueOrDefault(FingerprintAuthenticationNameKey, DefaultString);

            set => AppSettings.AddOrUpdateValue(FingerprintAuthenticationNameKey, value);
        }

        public static string FingerprintAuthenticationProvider
        {
            get => AppSettings.GetValueOrDefault(FingerprintAuthenticationProviderKey, DefaultString);

            set => AppSettings.AddOrUpdateValue(FingerprintAuthenticationProviderKey, value);
        }

        public static bool ShouldPurgeLocalStorage
        {
            get => AppSettings.GetValueOrDefault(ShouldPurgeLocalStorageKey, false);

            set => AppSettings.AddOrUpdateValue(ShouldPurgeLocalStorageKey, value);
        }

        public static DateTime LastLogin
        {
            get => AppSettings.GetValueOrDefault(LastLoginKey, default(DateTime));

            set => AppSettings.AddOrUpdateValue(LastLoginKey, value);
        }

        public static DateTime LastCriticalDataUpdate
        {
            get => AppSettings.GetValueOrDefault(LastCriticalDataUpdateKey, default(DateTime));

            set => AppSettings.AddOrUpdateValue(LastCriticalDataUpdateKey, value);
        }

        public static DateTime LastDataUpdate
        {
            get => AppSettings.GetValueOrDefault(LastDataUpdateKey, default(DateTime));

            set => AppSettings.AddOrUpdateValue(LastDataUpdateKey, value);
        }
    }
}
