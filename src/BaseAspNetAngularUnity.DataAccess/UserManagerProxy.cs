using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BaseAspNetAngularUnity.DataAccess;
using BaseAspNetAngularUnity.DataAccess.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaseAspNetAngularUnity.DataAccess
{
	public interface IUserManagerProxy
	{
		IdentityResult Create(ApplicationUser user, string password);
		IdentityResult AddToRole(string userId, string roleName);
		IdentityResult RemoveFromRole(string userId, string roleName);
		ApplicationUser GetApplicationUser(string userName);
		IQueryable<ApplicationUser> AllUsers();
		bool IsInRole(string userId, string role);
		Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser applicationUser, string authenticationType);
	}

	public class UserManagerProxy : IUserManagerProxy
	{
		private UserManager<ApplicationUser> UserManager;

		public UserManagerProxy(IDataAccessContext context)
		{
			this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>((DataAccessContext)context));
		}

		public IdentityResult Create(ApplicationUser user, string password)
		{
			return UserManager.Create(user, password);
		}

		// scope.UserManager.AddToRole(user.Id, RoleTypes.Administrator.ToString());
		public IdentityResult AddToRole(string userId, string roleName)
		{
			return UserManager.AddToRole(userId, roleName);
		}

		public IdentityResult RemoveFromRole(string userId, string roleName)
		{
			return UserManager.RemoveFromRole(userId, roleName);
		}


		public ApplicationUser GetApplicationUser(string userName)
		{
			return UserManager.FindByName(userName);
		}

		public IQueryable<ApplicationUser> AllUsers()
		{
			return UserManager.Users.Include(x => x.Roles);
		}

		public bool IsInRole(string userId, string role)
		{
			return UserManager.IsInRole(userId, role);
		}

		public Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser applicationUser, string authenticationType)
		{
			return UserManager.CreateIdentityAsync(applicationUser, authenticationType);
		}
	}
}
