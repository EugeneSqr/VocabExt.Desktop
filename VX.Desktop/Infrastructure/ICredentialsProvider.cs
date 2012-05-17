namespace VX.Desktop.Infrastructure
{
    public interface ICredentialsProvider
    {
        string UserKey { get; }

        string PasswordKey { get; }

        string User { get; }

        string Password { get; }
    }
}
