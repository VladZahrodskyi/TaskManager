using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class ApplicationUser : IdentityUser
	{

		//Navigation Property.
		//[ForeignKey("Person")]

		//public int PersonId { get; set; }
		public virtual Person Person { get; set; }
	}
}
