using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Entities;
using DAL.EF.Configurations;
using DAL.Identity;
namespace DAL.EF.Context
{
	//public class TaskManagerContext1:IdentityDbContext<ApplicationUser>
	//{
	//	public DbSet<Person> People { get; set; }
	//	public DbSet<TaskDAL> Tasks { get; set; }
	//	public DbSet<Status> Statuses { get; set; }
	//	//public DbSet<TaskTemplate> TaskTemplates { get; set; }
	//	public DbSet<Team> Teams { get; set; }
		
	//	public TaskManagerContext1():base("TaskManager")
	//	{
	//		Database.SetInitializer(new TaskManagerInitializer());
	//	}
	//	public TaskManagerContext1(string connectionString):base(connectionString)
	//	{
	//		Database.SetInitializer(new TaskManagerInitializer());
	//	}
	//	protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
	//	{
	//		base.OnModelCreating(dbModelBuilder);

	//		//dbModelBuilder.Configurations.Add(new ApplicationUserConfig());
	//		dbModelBuilder.Configurations.Add(new PersonConfig());
	//		dbModelBuilder.Configurations.Add(new StatusConfig());
	//		dbModelBuilder.Configurations.Add(new TaskDALConfig());
	//		dbModelBuilder.Configurations.Add(new TeamConfig());
			
	//	}
		
	//}
}
