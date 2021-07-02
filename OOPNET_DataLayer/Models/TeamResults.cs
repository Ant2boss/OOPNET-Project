using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

//Auto-generated using: https://app.quicktype.io/
namespace OOPNET_DataLayer.Models
{
    public class TeamResults : Team
    {
        [JsonProperty("wins")]
        public long Wins { get; set; }

        [JsonProperty("draws")]
        public long Draws { get; set; }

        [JsonProperty("losses")]
        public long Losses { get; set; }

        [JsonProperty("games_played")]
        public long GamesPlayed { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("goals_for")]
        public long GoalsFor { get; set; }

        [JsonProperty("goals_against")]
        public long GoalsAgainst { get; set; }

        [JsonProperty("goal_differential")]
        public long GoalDifferential { get; set; }
    }
}
