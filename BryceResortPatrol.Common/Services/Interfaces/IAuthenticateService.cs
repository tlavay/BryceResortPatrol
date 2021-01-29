namespace BryceResortPatrol.Common.Services.Interfaces
{
    public interface IAuthenticateService
    {
        string GetLoginToken(User user);
    }
}
