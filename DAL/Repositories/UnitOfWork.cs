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
	public class UnitOfWork : IUnitOfWork
	{
		private PersonRepository personRepository;
		private StatusRepository statusRepository;
		private TaskRepository taskRepository;
		private TeamRepository teamRepository;

		TaskManagerContext db;

		public UnitOfWork(string connectionString)
		{
			db = new TaskManagerContext(connectionString);
		}
		public IRepository<Person> People
		{
			get
			{
				if (personRepository == null)
				{
					personRepository = new PersonRepository(db);
				}
				return personRepository;
			}
		}

		public IRepository<Status> Statuses
		{
			get
			{
				if (statusRepository == null)
				{
					statusRepository = new StatusRepository(db);
				}
				return statusRepository;
			}
		}

		public IRepository<TaskDAL> Tasks
		{
			get
			{
				if (taskRepository == null)
				{
					taskRepository = new TaskRepository(db);
				}
				return taskRepository;
			}
		}

		public IRepository<Team> Teams
		{
			get
			{
				if (teamRepository == null)
				{
					teamRepository = new TeamRepository(db);
				}
				return teamRepository;
			}
		}

		public void Save()
		{
			db.SaveChanges() ;
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					db.Dispose();
				}	
				disposedValue = true;
			}
		}				
		public void Dispose()
		{			
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
