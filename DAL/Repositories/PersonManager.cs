using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using DAL.EF.Context;
namespace DAL.Repositories
{
	public class PersonManager : IPersonManager
	{
		private TaskManagerContext db { get; set; }

		public PersonManager(TaskManagerContext contex)
		{
			db = contex;
		}
		public Task<int> Create(Person person, string teamName)
		{
			var IsTeamExisting = db.Teams.Where(x=>x.TeamName ==teamName).Any();
			if (IsTeamExisting)
			{
				throw new ArgumentException($"Team is exist", teamName);
			}
			Team team = new Team() { TeamName = teamName };
			db.Teams.Add(team);
			
			person.TeamId = team.Id;
			//or call Create(person);
			db.People.Add(person);
			return db.SaveChangesAsync();
		}

		public int Create(Person person)//Task<int>    was 
		{
			db.People.Add(person);
			return db.SaveChanges();//db.SaveChangesAsync(); was
		}

		public void Dispose()
		{
			db.Dispose();
		}
	}
}
