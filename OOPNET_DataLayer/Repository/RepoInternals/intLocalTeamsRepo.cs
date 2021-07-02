using Newtonsoft.Json;
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
		private const string LOCAL_JSON_MALE_TEAMS_PATH = "LocalRepo/worldcup.sfg.io/men/teams.json";
		private const string LOCAL_JSON_MALE_TEAMS_RESULTS_PATH = "LocalRepo/worldcup.sfg.io/men/results.json";
		
		private const string LOCAL_JSON_FEMALE_TEAMS_PATH = "LocalRepo/worldcup.sfg.io/women/teams.json";
		private const string LOCAL_JSON_FEMALE_TEAMS_RESULTS_PATH = "LocalRepo/worldcup.sfg.io/women/results.json";

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
