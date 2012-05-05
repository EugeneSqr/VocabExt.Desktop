namespace VX.Desktop.ServiceFacade
{
    public interface IAuthServiceFacade
    {
        bool IsLoggedOn();

        bool LogOn();
    }
}
