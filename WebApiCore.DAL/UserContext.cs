using Microsoft.EntityFrameworkCore;
using WebApiCore.DAL.Entities;

namespace WebApiCore.DAL
{
    public class UserContext: DbContext
    {
        public UserContext() : base()
        {
            this.Database.Migrate();
        }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Integrated Security=SSPI; 
                Database=WebApiCore.DAL.UserContext; 
                Trusted_Connection=True;
                ConnectRetryCount=0";

            optionsBuilder.UseSqlServer(connection);
        }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<UserDataEntity> UserData { get; set; }
    }
}