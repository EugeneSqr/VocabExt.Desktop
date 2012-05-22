using System;

namespace VX.Desktop.ServiceFacade
{
    public interface IAuthServiceFacade
    {
        Guid Login(string userName, string password);
    }
}
