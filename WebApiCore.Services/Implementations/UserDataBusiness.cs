using System;
using System.Linq;
using AutoMapper;
using WebApiCore.Dtos;
using WebApiCore.Business.Interfaces;
using WebApiCore.DAL.Entities;
using WebApiCore.Repositories.Implementations;

namespace WebApiCore.Business.Implementations
{
    public class UserDataBusiness : IUserDataBusiness
    {
        private UserDataRepository UserDataRepository { get; set; }
        private readonly IMapper _mapper;

        public UserDataBusiness(IMapper mapper)
        {
            UserDataRepository = new UserDataRepository();
            this._mapper = mapper;
        }

        public void Create(UserDataDto model)
        {
            var isExisting = this.UserDataRepository.FindBy(ue => ue.Id == model.Id).Any();

            if (!isExisting)
            {
                this.UserDataRepository.Add(this._mapper.Map<UserDataEntity>(model));
                this.UserDataRepository.Save();
            }
            else
            {
                throw new Exception("User Data already exists");
            }
        }

        public UserDataDto Read(int id)
        {
            var userData = this.UserDataRepository.FindBy(ue => ue.Id == id).FirstOrDefault();

            return this._mapper.Map<UserDataDto>(userData);
        }

        public void Update(UserDataDto model)
        {
            this.UserDataRepository.Edit(this._mapper.Map<UserDataEntity>(model));
            this.UserDataRepository.Save();
        }

        public void Delete(int id)
        {
            var dto = this.Read(id);
            var entity = this._mapper.Map<UserDataEntity>(dto);

            this.UserDataRepository.Delete(entity);
            this.UserDataRepository.Save();
        }
    }
}
