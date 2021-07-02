using Newtonsoft.Json;

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
    }
}
