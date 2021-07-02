using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using OOPNET_DataLayer.Models;

namespace OOPNET_DataLayer.Repository
{
	public interface ITeamsRepo
	{
		/// <summary>
		/// Reads and parses JSON into a list of teams
		/// </summary>
		/// <returns><seealso cref="IList{Team}"/> of teams parsed</returns>
		/// <exception cref="FileNotFoundException"></exception>
		IList<Team> GetAllTeams();

		/// <summary>
		/// Reads and parses JSON into a list of team results
		/// </summary>
		/// <returns><seealso cref="IList{TeamResults}"/> of teams parsed</returns>
		/// <exception cref="FileNotFoundException"></exception>
		IList<TeamResults> GetAllTeamResults();
	}
}
