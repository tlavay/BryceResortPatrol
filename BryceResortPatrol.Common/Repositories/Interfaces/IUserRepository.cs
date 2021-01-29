using BryceResortPatrol.Common.Models;

namespace BryceResortPatrol.Common.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string username);
    }
}
