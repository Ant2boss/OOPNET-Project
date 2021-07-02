using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OOPNET_DataLayer.Models;
using RestSharp;

namespace OOPNET_DataLayer.Repository.RepoInternals
{
	internal class intWebTeamsRepo : ITeamsRepo
	{
		private const string JSON_MALE_TEAMS = "http://world-cup-json-2018.herokuapp.com/teams";
		private const string JSON_MALE_TEAMS_RESULTS = "http://world-cup-json-2018.herokuapp.com/teams/results";
		
		private const string JSON_FEMALE_TEAMS = "http://worldcup.sfg.io/teams";
		private const string JSON_FEMALE_TEAMS_RESULTS = "http://worldcup.sfg.io/teams/results";

		public IList<Team> GetAllTeams()
		{
			RestClient client = new RestClient(this._GetTeamsQuery());
			IRestResponse<Team> requestResult = client.Execute<Team>(new RestRequest());

			return JsonConvert.DeserializeObject<List<Team>>(requestResult.Content);
		}

		public IList<TeamResults> GetAllTeamResults()
		{
			RestClient client = new RestClient(this._GetTeamsResultsQuery());
			IRestResponse<TeamResults> requestResult = client.Execute<TeamResults>(new RestRequest());

			return JsonConvert.DeserializeObject<List<TeamResults>>(requestResult.Content);
		}

		public intWebTeamsRepo(CupType cupType)
		{
			this._cup = cupType;
		}

		private string _GetTeamsQuery() => (this._cup == CupType.MaleCup) ? (JSON_MALE_TEAMS) : (JSON_FEMALE_TEAMS);
		private string _GetTeamsResultsQuery() => (this._cup == CupType.MaleCup) ? (JSON_MALE_TEAMS_RESULTS) : (JSON_FEMALE_TEAMS_RESULTS);

		private CupType _cup;

	}
}
