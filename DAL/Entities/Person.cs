using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
namespace DAL.Entities
{
	public class Person//: IdentityUser
	{
		//[Key]
		public int Id { get; set; }

		//Navigation prop to ApplicationUser
		//[Required]
		//[ForeignKey("User")]
		public string /*Application*/UserId { get; set; }

		//Navigation prop to Team
		//[ForeignKey("Team")]
		public int? TeamId { get; set; }

		public string Name { get; set; }
		//Role
		public string Position { get; set; }

		public string Email { get; set; }

		public virtual Team Team { get; set; }

		//[Required]
		public virtual ApplicationUser /*Application*/User { get; set; }
	}
}
