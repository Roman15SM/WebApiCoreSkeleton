using System;

namespace WebApiCore.Dtos
{
    public class UserDataDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
