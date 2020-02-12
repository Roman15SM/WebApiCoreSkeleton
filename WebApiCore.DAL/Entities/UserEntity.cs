namespace WebApiCore.DAL.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserDataEntity UserData { get; set; }
    }
}
