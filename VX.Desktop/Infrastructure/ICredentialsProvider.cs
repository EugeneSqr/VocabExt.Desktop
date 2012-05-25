namespace VX.Desktop.Infrastructure
{
    public interface ICredentialsProvider
    {
        string UserKey { get; }

        string PasswordKey { get; }

        string User { get; set; }

        string Password { get; set; }

        void EmptyUser();
    }
}
