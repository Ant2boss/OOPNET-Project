using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

//Auto-generated using: https://app.quicktype.io/
namespace OOPNET_DataLayer.Models
{
	public class Team
	{
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public string AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public long GroupID { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

		public override bool Equals(object obj)
		{
			return obj is Team team &&
				   FifaCode == team.FifaCode;
		}
		public override int GetHashCode()
		{
			return -975964944 + EqualityComparer<string>.Default.GetHashCode(FifaCode);
		}

		public override string ToString() => $"{this.Country} ({this.FifaCode})";


	}
}
