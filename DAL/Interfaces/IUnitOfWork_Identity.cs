using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Identity;

namespace DAL.Interfaces
{
	public interface IUnitOfWork_Identity : IDisposable
	{
		ApplicationUserManager UserManager { get; }

		IPersonManager RersonManagerUOW { get; }

		ApplicationRoleManager RoleManager { get; }

		Task SaveAsync();
	}
}
