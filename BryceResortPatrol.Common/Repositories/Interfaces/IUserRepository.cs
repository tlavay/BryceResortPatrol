using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryceResortPatrol.Common.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string username);
    }
}
