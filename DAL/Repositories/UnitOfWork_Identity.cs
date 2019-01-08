using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using DAL.Identity;
using DAL.EF.Context;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Repositories
{
	public class UnitOfWork_Identity : IUnitOfWork_Identity
	{
		public ApplicationUserManager UserManager { get; }
		public IPersonManager RersonManagerUOW { get; }
		public ApplicationRoleManager RoleManager { get; }
		TaskManagerContext db;
		public UnitOfWork_Identity(string connectionString)
		{
			db = new TaskManagerContext(connectionString);
			UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
			RersonManagerUOW = new PersonManager(db);
			RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));

		}
		

		public async Task SaveAsync()
		{
			await db.SaveChangesAsync();
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					db.Dispose();				}

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
