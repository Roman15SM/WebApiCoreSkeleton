using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Business.Interfaces;
using WebApiCore.Dtos;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/userData")]
    public class UserDataController : MainController<UserDataModel>
    {
        private IUserDataBusiness UserDataBusiness { get; set; }
        private readonly IMapper _mapper;

        public UserDataController(IUserDataBusiness userDataBusiness, IMapper mapper)
        {
            this.UserDataBusiness = userDataBusiness;
            this._mapper = mapper;
        }

        [HttpGet("{id}")]
        public UserDataModel GetUserData(int id)
        {
            var userDataDto = this.UserDataBusiness.Read(id);
            var user = _mapper.Map<UserDataModel>(userDataDto);

            if (user == null)
                return new UserDataModel();

            return user;
        }

        [HttpPost]
        public StatusCodeResult Post([FromBody]UserDataModel model)
        {
            if (model == null)
                return Ok();

            var userDataDto = this._mapper.Map<UserDataDto>(model);
            this.UserDataBusiness.Create(userDataDto);

            return Ok();
        }
    }
}