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
	internal class intLocalTeamsRepo : ITeamsRepo
	{
		private static readonly string LOCAL_JSON_MALE_TEAMS_PATH = $"{ConfigFilePaths.LOCAL_REPO_JSON_DIR}/men/teams.json";
		private static readonly string LOCAL_JSON_MALE_TEAMS_RESULTS_PATH = $"{ConfigFilePaths.LOCAL_REPO_JSON_DIR}/men/results.json";
		
		private static readonly string LOCAL_JSON_FEMALE_TEAMS_PATH = $"{ConfigFilePaths.LOCAL_REPO_JSON_DIR}/women/teams.json";
		private static readonly string LOCAL_JSON_FEMALE_TEAMS_RESULTS_PATH = $"{ConfigFilePaths.LOCAL_REPO_JSON_DIR}/women/results.json";

		public IList<Team> GetAllTeams()
		{
			string fileContent = File.ReadAllText(this._GetTeamsQuery());
			return JsonConvert.DeserializeObject<List<Team>>(fileContent);
		}

		public IList<TeamResults> GetAllTeamResults()
		{
			string fileContent = File.ReadAllText(this._GetTeamsResultsQuery());
			return JsonConvert.DeserializeObject<List<TeamResults>>(fileContent);
		}

		public intLocalTeamsRepo(CupType cupType)
		{
			this._cup = cupType;
		}

		private string _GetTeamsQuery() => (this._cup == CupType.MaleCup) ? (LOCAL_JSON_MALE_TEAMS_PATH) : (LOCAL_JSON_FEMALE_TEAMS_PATH);
		private string _GetTeamsResultsQuery() => ((this._cup == CupType.MaleCup) ? (LOCAL_JSON_MALE_TEAMS_RESULTS_PATH) : (LOCAL_JSON_FEMALE_TEAMS_RESULTS_PATH));

		private CupType _cup;
	}
}
