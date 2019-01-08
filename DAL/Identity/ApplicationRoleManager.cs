using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Entities;

namespace DAL.Identity
{
	public class ApplicationRoleManager : Microsoft.AspNet.Identity.RoleManager<ApplicationRole>
	{
		public ApplicationRoleManager(RoleStore<ApplicationRole> store)
					: base(store)
		{ }
	}
}
