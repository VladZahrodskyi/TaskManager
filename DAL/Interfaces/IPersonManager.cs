using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
	public interface IPersonManager:IDisposable
	{
		Task<int> Create(Person person, string teamName);

		int Create(Person person);//Task<int>  was
	}
}
