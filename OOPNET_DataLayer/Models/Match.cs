using Newtonsoft.Json;
using OOPNET_DataLayer.Models.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Auto-generated using: https://app.quicktype.io/
namespace OOPNET_DataLayer.Models
{
	public class Match
	{
		[JsonProperty("venue")]
		public string Venue { get; set; }

		[JsonProperty("location")]
		public string Location { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("time")]
		public string Time { get; set; }

		[JsonProperty("fifa_id")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long FifaID { get; set; }

		[JsonProperty("weather")]
		public MatchWeather Weather { get; set; }

		[JsonProperty("attendance")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long Attendance { get; set; }

		[JsonProperty("officials")]
		public IList<string> Officials { get; set; }

		[JsonProperty("stage_name")]
		public string StageName { get; set; }

		[JsonProperty("home_team_country")]
		public string HomeTeamCountry { get; set; }

		[JsonProperty("away_team_country")]
		public string AwayTeamCountry { get; set; }

		[JsonProperty("datetime")]
		public DateTimeOffset Datetime { get; set; }

		[JsonProperty("winner")]
		public string Winner { get; set; }

		[JsonProperty("winner_code")]
		public string WinnerCode { get; set; }

		[JsonProperty("home_team")]
		public MatchTeam HomeTeam { get; set; }

		[JsonProperty("away_team")]
		public MatchTeam AwayTeam { get; set; }

		[JsonProperty("home_team_events")]
		public IList<MatchTeamEvent> HomeTeamEvents { get; set; }

		[JsonProperty("away_team_events")]
		public IList<MatchTeamEvent> AwayTeamEvents { get; set; }

		[JsonProperty("home_team_statistics")]
		public MatchTeamStatistics HomeTeamStatistics { get; set; }

		[JsonProperty("away_team_statistics")]
		public MatchTeamStatistics AwayTeamStatistics { get; set; }

		[JsonProperty("last_event_update_at")]
		public DateTimeOffset LastEventUpdateAt { get; set; }

		[JsonProperty("last_score_update_at")]
		public DateTimeOffset? LastScoreUpdateAt { get; set; }

		public static IList<Match> ParseJsonToMatches(string Json)
		{
			return JsonConvert.DeserializeObject<List<Match>>(Json, Converter.Settings);
		}
	}
}
