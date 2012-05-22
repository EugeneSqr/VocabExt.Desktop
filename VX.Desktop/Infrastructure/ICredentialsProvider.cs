using System;

namespace VX.Desktop.Infrastructure
{
    public interface ICredentialsProvider
    {
        Guid CurrentToken { get; set; }
    }
}
