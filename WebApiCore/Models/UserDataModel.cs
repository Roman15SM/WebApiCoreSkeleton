using System;

namespace WebApiCore.Models
{
    public class UserDataModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
