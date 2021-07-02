using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using OOPNET_DataLayer.Models;
using Newtonsoft.Json;

namespace OOPNET_DataLayer.Repository
{
	public interface IMatchesRepo
	{
		/// <summary>
		/// Reads and parses the JSON file containing information of matches
		/// </summary>
		/// <returns><seealso cref="IList{Match}"/> of all the parsed matches</returns>
		/// <exception cref="FileNotFoundException"></exception>
		IList<Match> GetAllMatches();

		/// <summary>
		/// Reads and parses the JSON file containing information of matches of specified country
		/// </summary>
		/// <param name="FifaCode">Fifa code of country to filter for</param>
		/// <returns><seealso cref="IList{Match}"/> of all the parsed matches</returns>
		/// <exception cref="FileNotFoundException"></exception>
		/// <exception cref="JsonSerializationException"></exception>
		IList<Match> GetMatchesOfCountry(string FifaCode);
	}
}
