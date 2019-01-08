using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DAL.Entities
{
	public class Team
	{
		//[Key]
		public int Id { get; set; }

		public string TeamName { get; set; }

		public virtual ICollection<Person> People { get; set; }

		public Team()
		{
			People = new List<Person>();
		}
	}
}
