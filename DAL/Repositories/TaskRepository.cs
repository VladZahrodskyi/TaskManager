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
	public class TaskRepository : IRepository<TaskDAL>
	{
		TaskManagerContext db;
		public TaskRepository(TaskManagerContext context)
		{
			db = context;
		}
		public int Create(TaskDAL task)
		{
			db.Tasks.Add(task);
			return db.SaveChanges();
		}

		public int Delete(int id)
		{
			TaskDAL task = db.Tasks.Find(id);
			if (task != null)
			{
				db.Tasks.Remove(task);
			}
			return db.SaveChanges();
		}

		public IEnumerable<TaskDAL> Find(Func<TaskDAL, bool> predicate)
		{
			return db.Tasks.Where(predicate);
		}

		public TaskDAL Get(int id)
		{
			return db.Tasks.Find(id);
		}

		public IEnumerable<TaskDAL> GetAll()
		{
			return db.Tasks;
		}

		public int Update(TaskDAL task)
		{
			db.Entry<TaskDAL>(task).State = System.Data.Entity.EntityState.Modified ;
			return db.SaveChanges();
		}
	}
}
