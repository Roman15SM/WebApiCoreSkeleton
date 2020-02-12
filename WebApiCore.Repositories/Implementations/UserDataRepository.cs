using WebApiCore.DAL;
using WebApiCore.DAL.Entities;
using WebApiCore.Repositories.Interfaces;

namespace WebApiCore.Repositories.Implementations
{
    public class UserDataRepository: BaseRepository<UserContext, UserDataEntity>, IUserDataRepository
    {
    }
}
