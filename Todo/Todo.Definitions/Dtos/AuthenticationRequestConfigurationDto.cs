namespace NsuGo.Definition.Dtos
{
    public class AuthenticationRequestConfigurationDto
    {
		public string Reason { get; }

		/// <summary>
		/// Title of the cancel button.
		/// </summary>
		public string CancelTitle { get; set; }

		/// <summary>
		/// Title of the fallback button.
		/// </summary>
		public string FallbackTitle { get; set; }

		/// <summary>
		/// En-/Disables the dialog. 
		/// Supported Platforms: Android
		/// Default: true
		/// </summary>
		public bool UseDialog { get; set; } = true;

		/// <summary>
		/// Shown when a recoverable error has been encountered during authentication. 
		/// The help strings are provided to give the user guidance for what went wrong.
		/// If a string is null or empty, the string provided by Android is shown.
		/// Supported Platforms: Android (when UseDialog is true)
		/// </summary>
		public AuthenticationHelpTextsDto HelpTexts { get; }

		/// <summary>
		/// En-/Disables the use of the PIN / Passwort as fallback.
		/// Supported Platforms: iOS, Mac
		/// Default: false
		/// </summary>
		public bool AllowAlternativeAuthentication { get; set; } = false;

		public AuthenticationRequestConfigurationDto(string reason)
		{
			Reason = reason;
			HelpTexts = new AuthenticationHelpTextsDto();
		}
    }
}
