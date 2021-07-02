using Newtonsoft.Json;
using System;

//Auto-generated using: https://app.quicktype.io/
namespace OOPNET_DataLayer.Models.Converters
{
	internal class DescriptionConverter : JsonConverter
	{
		public override bool CanConvert(Type t) => t == typeof(Description) || t == typeof(Description?);

		public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;
			var value = serializer.Deserialize<string>(reader);
			switch (value)
			{
				case "Cloudy":
					return Description.Cloudy;
				case "Cloudy Night":
					return Description.CloudyNight;
				case "Partly Cloudy":
					return Description.PartlyCloudy;
				case "Partly Cloudy Night":
					return Description.PartlyCloudyNight;
				case "Sunny":
					return Description.Sunny;
			}
			throw new Exception("Cannot unmarshal type Description");
		}

		public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
		{
			if (untypedValue == null)
			{
				serializer.Serialize(writer, null);
				return;
			}
			var value = (Description)untypedValue;
			switch (value)
			{
				case Description.Cloudy:
					serializer.Serialize(writer, "Cloudy");
					return;
				case Description.CloudyNight:
					serializer.Serialize(writer, "Cloudy Night");
					return;
				case Description.PartlyCloudy:
					serializer.Serialize(writer, "Partly Cloudy");
					return;
				case Description.PartlyCloudyNight:
					serializer.Serialize(writer, "Partly Cloudy Night");
					return;
				case Description.Sunny:
					serializer.Serialize(writer, "Sunny");
					return;
			}
			throw new Exception("Cannot marshal type Description");
		}

		public static readonly DescriptionConverter Singleton = new DescriptionConverter();
	}
}