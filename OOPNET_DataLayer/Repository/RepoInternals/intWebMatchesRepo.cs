using Newtonsoft.Json;
using OOPNET_DataLayer.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_DataLayer.Repository.RepoInternals
{
	internal class intWebMatchesRepo : IMatchesRepo
	{
		private const string JSON_MALE_MATCHES = "http://world-cup-json-2018.herokuapp.com/matches";
		private const string JSON_MALE_MATCHES_OF_COUNTRY = "http://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";

		private const string JSON_FEMALE_MATCHES = "http://worldcup.sfg.io/matches/";
		private const string JSON_FEMALE_MATCHES_OF_COUNTRY = "http://worldcup.sfg.io/matches/country?fifa_code=";

		public IList<Match> GetAllMatches()
		{
			RestClient client = new RestClient(this._GetTeamsQuery());
			IRestResponse<Match> requestResult = client.Execute<Match>(new RestRequest());

			return JsonConvert.DeserializeObject<List<Match>>(requestResult.Content);
		}

		public IList<Match> GetMatchesOfCountry(string FifaCode)
		{
			RestClient client = new RestClient(this._GetTeamsResultsQuery(FifaCode));
			IRestResponse<Match> requestResult = client.Execute<Match>(new RestRequest());

			return JsonConvert.DeserializeObject<List<Match>>(requestResult.Content);
		}

		public intWebMatchesRepo(CupType cupType)
		{
			this._cup = cupType;
		}

		private string _GetTeamsQuery() => (this._cup == CupType.MaleCup) ? (JSON_MALE_MATCHES) : (JSON_FEMALE_MATCHES);
		private string _GetTeamsResultsQuery(string FifaCode) => ((this._cup == CupType.MaleCup) ? (JSON_MALE_MATCHES_OF_COUNTRY) : (JSON_FEMALE_MATCHES_OF_COUNTRY)) + FifaCode;

		private CupType _cup;
	}
}
