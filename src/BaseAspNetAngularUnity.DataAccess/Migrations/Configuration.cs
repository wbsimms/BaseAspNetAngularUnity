using System.IO;

namespace BaseAspNetAngularUnity.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BaseAspNetAngularUnity.DataAccess.DataAccessContext>
    {
		
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BaseAspNetAngularUnity.DataAccess.DataAccessContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

			AddLoggingTables(context);
        }

		private void AddLoggingTables(DataAccessContext context)
		{
			string databaseSql =
				new StreamReader(
					this.GetType()
						.Assembly.GetManifestResourceStream(
							"BaseAspNetAngularUnity.DataAccess.Migrations.Scripts.CreateLoggingDatabaseObjects.sql")).ReadToEnd();
			context.Database.ExecuteSqlCommand(databaseSql);
		}
	}
}
