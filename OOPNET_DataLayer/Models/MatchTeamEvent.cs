using Newtonsoft.Json;
using OOPNET_DataLayer.Models.Converters;

//Auto-generated using: https://app.quicktype.io/
namespace OOPNET_DataLayer.Models
{
	public class MatchTeamEvent
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("type_of_event")]
        [JsonConverter(typeof(TypeOfEventConverter))]
        public TypeOfEvent TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
