using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApiCore.Dtos;
using WebApiCore.Business.Interfaces;
using WebApiCore.DAL.Entities;
using WebApiCore.Repositories.Implementations;

namespace WebApiCore.Business.Implementations
{
    public class UserBusiness : IUserBusiness
    {
        private UserRepository UserRepository { get; set; }
        private readonly IMapper _mapper;

        public UserBusiness(IMapper mapper)
        {
            UserRepository = new UserRepository();
            this._mapper = mapper;
        }

        public void Create(UserDto model)
        {
            var isExisting = this.UserRepository.FindBy(ue => ue.Username == model.Username).Any();

            if (!isExisting)
            {
                this.UserRepository.Add(this._mapper.Map<UserEntity>(model));
                this.UserRepository.Save();
            }
            else
            {
                throw new Exception("User already exists");
            }
        }

        public UserDto Read(int id)
        {
            var user = this.UserRepository.FindBy(ue => ue.Id == id).FirstOrDefault();

            return this._mapper.Map<UserDto>(user);
        }

        public void Update(UserDto model)
        {
            this.UserRepository.Edit(this._mapper.Map<UserEntity>(model));
            this.UserRepository.Save();
        }

        public void Delete(int id)
        {
            var dto = this.Read(id);
            var entity = this._mapper.Map<UserEntity>(dto);

            this.UserRepository.Delete(entity);
            this.UserRepository.Save();
        }

        public List<UserDto> GetAll()
        {
            var userEntities = this.UserRepository.FindBy(ue => ue.Id > 0).ToList();
            var users = this._mapper.Map<List<UserDto>>(userEntities);

            return users;
        }
    }
}
