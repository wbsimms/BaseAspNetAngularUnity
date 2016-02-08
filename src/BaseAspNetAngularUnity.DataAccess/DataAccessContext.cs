using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using BaseAspNetAngularUnity.DataAccess.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaseAspNetAngularUnity.DataAccess
{
	public interface IDataAccessContext
	{
		DbSet<Log> Logs { get; set; }
		DbSet<CategoryLog> CategoryLogs { get; set;}
	}

	public class DataAccessContext : IdentityDbContext<ApplicationUser>, IDataAccessContext
	{
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DataAccessContext() : base("DefaultConnection")
		{
		}

		public DbSet<Log> Logs { get; set; }
		public DbSet<CategoryLog> CategoryLogs { get; set; }

		public static DataAccessContext Create()
		{
			return new DataAccessContext();
		}
	}
}

