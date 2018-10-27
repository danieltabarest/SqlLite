namespace NsuGo.Definition.Enums
{
    public enum FingerprintAuthenticationResultStatus
    {
		Unknown,
		Succeeded,
		FallbackRequested,
		Failed,
		Canceled,
		TooManyAttempts,
		UnknownError,
		NotAvailable
    }
}
