using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using DAL.EF.Context;
using DAL.Repositories;
namespace DAL.Repositories
{

	public class PersonRepository : IRepository<Person>
	{
		TaskManagerContext db;
		PersonManager userCreater;//We call PersonManager to create an instance for new person.
		public PersonRepository(TaskManagerContext context)
		{
			db = context;
			userCreater = new PersonManager(context);
		}
		public int Create(Person person)
		{
			userCreater.Create(person);
			return db.SaveChanges();
			//if (db.Entry<Person>(person).State == System.Data.Entity.EntityState.Added)
			//{
			//	db.SaveChangesAsync();
			//	return true;
			//}
			//return false;
		}

		public int Delete(int id)
		{
			Person person = db.People.Find(id);
			if(person!=null)//
			db.People.Remove(person);
			return db.SaveChanges();
			//if (db.Entry<Person>(person).State == System.Data.Entity.EntityState.Deleted)
			//{
			//	db.SaveChangesAsync();
			//	return true;
			//}
			//return false;
		}

		public IEnumerable<Person> Find(Func<Person, bool> predicate)
		{
			return db.People.Where(predicate);
		}

		public Person Get(int id)
		{
			return db.People.Where(x => x.Id == id).First();
		}

		public IEnumerable<Person> GetAll()
		{
			return db.People;//.AsEnumerable();
		}

		public int Update(Person person)
		{
			db.Entry<Person>(person).State = System.Data.Entity.EntityState.Modified;
			return db.SaveChanges();
			//if(db.People.FindAsync(person)!=null)
			//{
			//	try
			//	{
			//		db.Entry<Person>(person).State = System.Data.Entity.EntityState.Modified;
			//	}
			//	catch (Exception)
				
			//		return false;
			//	}
			//	return true;
			//}
			//else
			//{
			//	throw new ArgumentNullException("There is no any person with this id");
			//}

		}
	}
}
