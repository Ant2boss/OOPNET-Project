using Newtonsoft.Json;
using System.Collections.Generic;

//Auto-generated using: https://app.quicktype.io/
namespace OOPNET_DataLayer.Models
{
	public class MatchTeam
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }

		public override string ToString() => $"{this.Country} ({this.Code})";

		public override bool Equals(object obj)
		{
			return obj is MatchTeam team &&
				   Code == team.Code;
		}
		public override int GetHashCode()
		{
			return -434485196 + EqualityComparer<string>.Default.GetHashCode(Code);
		}
	}
}
