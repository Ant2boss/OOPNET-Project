using Newtonsoft.Json;
using OOPNET_DataLayer.Configs;
using OOPNET_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_DataLayer.Repository.RepoInternals
{
	internal class intLocalMatchesRepo : IMatchesRepo
	{
		private static readonly string LOCAL_JSON_MALE_MATCHES_PATH = $"{ConfigFilePaths.LOCAL_REPO_JSON_DIR}/men/matches.json";
		private static readonly string LOCAL_JSON_FEMALE_MATCHES_PATH = $"{ConfigFilePaths.LOCAL_REPO_JSON_DIR}/women/matches.json";

		public IList<Match> GetAllMatches()
		{
			string fileContent = File.ReadAllText(this._GetMatchQuery());
			return JsonConvert.DeserializeObject<List<Match>>(fileContent);
		}

		public IList<Match> GetMatchesOfCountry(string FifaCode)
		{
			return this.GetAllMatches()
				.Where(m => m.HomeTeam.Code.ToLower() == FifaCode.ToLower() || m.AwayTeam.Code.ToLower() == FifaCode.ToLower())
				.ToList();
		}

		public intLocalMatchesRepo(CupType cupType)
		{
			this._cup = cupType;
		}

		private string _GetMatchQuery() => (this._cup == CupType.MaleCup) ? (LOCAL_JSON_MALE_MATCHES_PATH) : (LOCAL_JSON_FEMALE_MATCHES_PATH);

		private CupType _cup;
	}
}
