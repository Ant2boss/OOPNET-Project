using Newtonsoft.Json;
using OOPNET_DataLayer.Models.Converters;

//Auto-generated using: https://app.quicktype.io/
namespace OOPNET_DataLayer.Models
{
	public class MatchStartingEleven
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        [JsonConverter(typeof(PositionConverter))]
        public Position Position { get; set; }
    }
}
