using Newtonsoft.Json;
using OOPNET_DataLayer.Models.Converters;
using System;
using System.Collections.Generic;

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

		public override bool Equals(object obj)
		{
			return obj is MatchPlayer player &&
				   Name == player.Name &&
				   Captain == player.Captain &&
				   ShirtNumber == player.ShirtNumber &&
				   Position == player.Position;
		}
		public override int GetHashCode()
		{
			int hashCode = 412083565;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + Captain.GetHashCode();
			hashCode = hashCode * -1521134295 + ShirtNumber.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Position);
			return hashCode;
		}
	}
}
