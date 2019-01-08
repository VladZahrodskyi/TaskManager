using DAL.Entities;
using DAL.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Context
{
	class TaskManagerInitializer : DropCreateDatabaseAlways<TaskManagerContext>
	{
		protected override void Seed(TaskManagerContext context)
		{
			IdentityInitialSetup(context);

			base.Seed(context);
		}
		public void IdentityInitialSetup(TaskManagerContext context)
		{
			var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

			// Creating 2 roles
			var role1 = new IdentityRole { Name = "Manager" };
			var role2 = new IdentityRole { Name = "Programmer" };

			// Adding them to manager of roles
			roleManager.Create(role1);
			roleManager.Create(role2);

			// Creating manager and programmer
			var manager = new ApplicationUser { Email = "Manager1_mail@gmail.com", UserName = "Manager1Name" };
			string password = "_Manager1_";

			var result = userManager.Create(manager, password);
			if (result.Succeeded)
			{
				// Adding role for him
				userManager.AddToRole(manager.Id, role1.Name);
				//userManager.AddToRole(manager.Id, role2.Name);
			}
			/// Add to table Person
			var person = new Person { Name = manager.UserName, Email = manager.Email, Position = role1.Name, User = manager};
			var team = new Team { TeamName = "Team1" };
			context.Teams.Add(team);
			person.TeamId = team.Id;
			context.People.Add(person);
		}
	}
}
