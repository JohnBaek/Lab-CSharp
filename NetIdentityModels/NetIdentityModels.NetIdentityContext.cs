using Microsoft.EntityFrameworkCore;
using Scaffold.API.V1.Models;

namespace Scaffold.API.V1.Models
{
    /// <summary>
    /// 생성자
    /// </summary>
    public class NetIdentityContext : DbContext
    {
        public DbSet<ClaimName> ClaimName { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleClaim> RoleClaim { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserClaim> UserClaim { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public NetIdentityContext(DbContextOptions<NetIdentityContext> options) : base(options) { }
    } 
}
