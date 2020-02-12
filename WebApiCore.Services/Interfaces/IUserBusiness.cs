using System.Collections.Generic;
using WebApiCore.Dtos;
namespace WebApiCore.Business.Interfaces
{
    public interface IUserBusiness: IBusiness<UserDto>
    {
        List<UserDto> GetAll();
    }
}
