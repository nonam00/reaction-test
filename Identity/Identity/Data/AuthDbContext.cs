using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Data
{
	public class AuthDbContext : IdentityDbContext<AppUser>
	{
		public AuthDbContext(DbContextOptions<AuthDbContext> options)
			: base(options) { }

		protected override void OnModelCreating(ModelBuilder buidler)
		{
			base.OnModelCreating(buidler);

			buidler.Entity<AppUser>(entity =>
				entity.ToTable(name: "Users"));
			buidler.Entity<IdentityRole>(entity =>
				entity.ToTable(name: "Roles"));
			buidler.Entity<IdentityUserRole<string>>(entity =>
				entity.ToTable(name: "UserRoles"));
			buidler.Entity<IdentityUserClaim<string>>(entity =>
				entity.ToTable(name: "UserCalim"));
			buidler.Entity<IdentityUserLogin<string>>(entity =>
				entity.ToTable("UserLogins"));
			buidler.Entity<IdentityUserToken<string>>(entity =>
				entity.ToTable("UserTokens"));
			buidler.Entity<IdentityRoleClaim<string>>(entity =>
				entity.ToTable("RoleClaims"));

			buidler.ApplyConfiguration(new AppUserConfiguration());
		}
	}
}
