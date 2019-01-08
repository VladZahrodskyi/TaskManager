namespace DAL.EF.Context
{
	using System;
	using System.Data.Entity;
	using System.Linq;
	using DAL.Entities;
	using DAL.EF.Configurations;
	using Microsoft.AspNet.Identity.EntityFramework;

	public class TaskManagerContext : IdentityDbContext<ApplicationUser>
	{
		
		public TaskManagerContext()
			: base("name=TaskManagerContext")
		{
			Database.SetInitializer(new TaskManagerInitializer());
			//Database.Delete();
		}
		public TaskManagerContext(string connectionString) : base(connectionString)
		{
			Database.SetInitializer(new TaskManagerInitializer());
			//Database.Delete();
		}
		public DbSet<Person> People { get; set; }
		public DbSet<TaskDAL> Tasks { get; set; }
		public DbSet<Status> Statuses { get; set; }
		//public DbSet<TaskTemplate> TaskTemplates { get; set; }
		public DbSet<Team> Teams { get; set; }

		protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
		{
			base.OnModelCreating(dbModelBuilder);

			//We use DataAnnotation, but if we want to use Fluent Api
			//, we must define it here
			dbModelBuilder.Configurations.Add(new ApplicationUserConfig());
			dbModelBuilder.Configurations.Add(new PersonConfig());
			dbModelBuilder.Configurations.Add(new StatusConfig());
			dbModelBuilder.Configurations.Add(new TaskDALConfig());
			dbModelBuilder.Configurations.Add(new TeamConfig());

		}
	}
}