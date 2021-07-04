using Newtonsoft.Json;
using OOPNET_DataLayer.Models.Converters;
using System;

//Auto-generated using: https://app.quicktype.io/
namespace OOPNET_DataLayer.Models
{
	public class MatchPlayer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

		public static MatchPlayer ParseFileLine(string line, char del)
		{
            string[] lineParts = line.Split(del);

            if (lineParts.Length != 4)
            {
                return null;
            }

            MatchPlayer player = new MatchPlayer();

            player.Name = lineParts[0];
            player.Captain = bool.Parse(lineParts[1]);
            player.ShirtNumber = long.Parse(lineParts[2]);
            player.Position = lineParts[3];

            return player;
        }

        public string FormatForFileLine(char del) => $"{this.Name}{del}{this.Captain}{del}{this.ShirtNumber}{del}{this.Position}";
	}
}
