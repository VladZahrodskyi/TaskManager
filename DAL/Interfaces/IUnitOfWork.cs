using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
	public interface IUnitOfWork:IDisposable
	{
	

		IRepository<Person> People { get; }

		IRepository<Status> Statuses { get; }

		IRepository<TaskDAL> Tasks { get; }

		//IRepository<TaskTemplate> TaskTemplates { get; }

		IRepository<Team> Teams { get; }

		void Save();
	}
}
