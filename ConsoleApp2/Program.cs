using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.Entities;
using DAL.EF.Context;
using Microsoft.AspNet.Identity;

using System.Data.Entity;

namespace ConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			using (TaskManagerContext db = new TaskManagerContext("name=TaskManagerContext"))
			{
				//ApplicationUser user = new ApplicationUser { };
				//Person person = new Person { }
				//db.People.Add();
				//Console.WriteLine("I was running");

				//IUnitOfWork inst = new UnitOfWork("name=TaskManagerContex");
				//IUnitOfWork_Identity identity = new UnitOfWork_Identity("name=TaskManagerContex");
				//var user = new ApplicationUser { Email = "dcdnsndcnjsn1", UserName = "eddeded" };
				//var result = identity.UserManager.CreateIdentityAsync(user, "1233123");
				////result.
				//var user_1 = identity.UserManager.FindByNameAsync(user.UserName);

				//var res = identity.UserManager.AddToRoleAsync(user_1.Result.Id, "Manageree");

				//var person = new Personе { ApplicationUser = new ApplicationUser { Id = user_1.Result.Id }, Name = user_1.Result.UserName, Email = user.Email, Position = "FFF" };
				//int answear = inst.People.Create(person);

				//Console.WriteLine(answear);
				//Console.WriteLine();

				//db.People.Add();
				Console.WriteLine(db.Database.Connection.ToString());

				IUnitOfWork inst = new UnitOfWork("name=TaskManagerContext");
				IUnitOfWork_Identity identity = new UnitOfWork_Identity("name=TaskManagerContext");
				var user = new ApplicationUser { Email = "ddnsndcnjsn", UserName = "eddeded" };
				var result = identity.UserManager.CreateAsync(user, "1233123");
				var res = identity.UserManager.AddToRoleAsync(user.Id, "Manager");
				var person = new Person { /*Application*User = user,*/ Name = user.UserName, Email = user.Email, Position = "Manager" };
				user.Person = person;
				identity.UserManager.UpdateAsync(user);
				person.User = user;
				int answear = inst.People.Create(person);

				Console.WriteLine(answear);
				Console.WriteLine();
			}
			Console.WriteLine("The end of connection");
			Console.ReadKey();
			//	var i=MyMethAsync();
			//using (TaskManagerContext db = new TaskManagerContext("name=TaskManagerContext"))
			//{
			//	Console.WriteLine(db.Database.Connection.ToString());
				
			//	IUnitOfWork inst = new UnitOfWork("name=TaskManagerContext");
			//	IUnitOfWork_Identity identity = new UnitOfWork_Identity("name=TaskManagerContext");
			//	var user = new ApplicationUser { Email = "dcdnsndcnjsn", UserName = "eddeded" };
			//	var result = identity.UserManager.CreateAsync(user, "1233123");
			//	var res = identity.UserManager.AddToRole(user.Id, "Manager");
			//	var person = new Person { ApplicationUserId = user.Id, Name = user.UserName, Email = user.Email };
			//	int answear = inst.People.Create(person);
				
			//	Console.WriteLine(answear);
			//	Console.WriteLine(	);
			//}
			//Console.ReadLine();
		}
		public static async Task MyMethAsync()
		{
			using (TaskManagerContext db = new TaskManagerContext("name=TaskManagerContext"))
			{
				Console.WriteLine(db.Database.Connection.ToString());

				IUnitOfWork inst = new UnitOfWork("name=TaskManagerContext");
				IUnitOfWork_Identity identity = new UnitOfWork_Identity("name=TaskManagerContext");
				var user = new ApplicationUser { Email = "dcdnsndcnjsn", UserName = "eddeded" };
				var result = await identity.UserManager.CreateAsync(user, "1233123");
				var res =  identity.UserManager.AddToRole(user.Id, "Manager");
				var person = new Person { /*Application*/User = new ApplicationUser {Id = user.Id }, Name = user.UserName, Email = user.Email };
				int answear = inst.People.Create(person);
				
				Console.WriteLine(answear);
				Console.WriteLine();
			}
			Console.ReadLine();
		}
	}
}
