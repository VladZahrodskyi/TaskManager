using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using DAL.EF.Context;
namespace DAL.Repositories
{
	public class TeamRepository : IRepository<Team>
	{
		TaskManagerContext db;
		public TeamRepository(TaskManagerContext context)
		{
			db = context;
		}
		public int Create(Team team)
		{
			db.Teams.Add(team);
			return db.SaveChanges();
		}

		public int Delete(int id)
		{
			Team team = db.Teams.Find(id);
			if (team != null)
			{
				db.Teams.Remove(team);
			}
			return db.SaveChanges();
		}

		public IEnumerable<Team> Find(Func<Team, bool> predicate)
		{
			return db.Teams.Where(predicate);
		}

		public Team Get(int id)
		{
			return db.Teams.Find(id);
		}

		public IEnumerable<Team> GetAll()
		{
			return db.Teams;
		}

		public int Update(Team team)
		{
			db.Entry<Team>(team).State=System.Data.Entity.EntityState.Modified;
			return db.SaveChanges();
		}
	}
}
