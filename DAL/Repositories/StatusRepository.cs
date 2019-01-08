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
	public class StatusRepository : IRepository<Status>
	{
		private TaskManagerContext db;
		public StatusRepository(TaskManagerContext context)
		{
			db = context;
		}
		public int Create(Status status)
		{
			db.Statuses.Add(status);
			return db.SaveChanges();
			//if (db.Entry<Status>(status).State == System.Data.Entity.EntityState.Added)
			//{
			//	db.SaveChangesAsync();
			//	return true;
			//}
			//else
			//{
			//	db.Entry<Status>(status).State = System.Data.Entity.EntityState.Deleted;
			//	db.SaveChangesAsync();
			//	return false;
			//}

		}

		public int Delete(int id)
		{
			Status status = db.Statuses.Find(id);
			if (status != null)
			{
				db.Statuses.Remove(status);
			}
			return db.SaveChanges();
		}

		public IEnumerable<Status> Find(Func<Status, bool> predicate)
		{
			return db.Statuses.Where(predicate);
		}

		public Status Get(int id)
		{
			return db.Statuses.Find(id);
		}

		public IEnumerable<Status> GetAll()
		{
			return db.Statuses;
		}

		public int Update(Status status)
		{
			db.Entry<Status>(status).State = System.Data.Entity.EntityState.Modified;
			return db.SaveChanges();
		}
	}
}
