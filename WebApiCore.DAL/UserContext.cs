using Microsoft.EntityFrameworkCore;
using WebApiCore.DAL.Entities;

namespace WebApiCore.DAL
{
    public class UserContext: DbContext
    {
        public UserContext() : base()
        {
        }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Server=PRGLAPD6G9HM2\ROLAND;Database=WebApiCore.DAL.UserContext;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<UserContext>(options => options.UseSqlServer(connection));

            optionsBuilder.UseSqlServer(connection);
        }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<UserDataEntity> UserData { get; set; }
    }
}