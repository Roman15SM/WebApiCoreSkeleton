using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Business.Interfaces;
using WebApiCore.Dtos;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : MainController<UserModel>
    {
        private IUserBusiness UserBusiness { get; set; }
        private readonly IMapper _mapper;

        public UserController(IUserBusiness userBusiness, IMapper mapper)
        {
            this.UserBusiness = userBusiness;
            this._mapper = mapper;
        }

        [HttpGet("{id}")]
        public UserModel GetUser(int id)
        {
            var userDto = this.UserBusiness.Read(id);
            var user = _mapper.Map<UserModel>(userDto);

            if(user == null)
                return new UserModel();

            return user;
        }

        [HttpPost]
        public StatusCodeResult Post([FromBody]UserModel model)
        {
            if (model == null)
                return Ok();

            var userDto = this._mapper.Map<UserDto>(model);
            this.UserBusiness.Create(userDto);

            return Ok();
        }

        [HttpGet]
        [Route("all")]
        public List<UserModel> All()
        {
            var userDtos = this.UserBusiness.GetAll();
            var users = _mapper.Map<List<UserModel>>(userDtos);

            if (users == null)
                return new List<UserModel>();

            return users;
        }
    }
}