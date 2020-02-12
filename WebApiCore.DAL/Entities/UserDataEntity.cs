using System;

namespace WebApiCore.DAL.Entities
{
    public class UserDataEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public UserEntity User { get; set; }
    }
}
