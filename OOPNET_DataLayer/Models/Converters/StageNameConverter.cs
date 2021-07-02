using Newtonsoft.Json;
using System;

//Auto-generated using: https://app.quicktype.io/
namespace OOPNET_DataLayer.Models.Converters
{
	internal class StageNameConverter : JsonConverter
	{
		public override bool CanConvert(Type t) => t == typeof(StageName) || t == typeof(StageName?);

		public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;
			var value = serializer.Deserialize<string>(reader);
			switch (value)
			{
				case "Final":
					return StageName.Final;
				case "First Stage":
					return StageName.FirstStage;
				case "Match for third place":
					return StageName.MatchForThirdPlace;
				case "Quarter-final":
					return StageName.QuarterFinal;
				case "Round of 16":
					return StageName.RoundOf16;
				case "Semi-final":
					return StageName.SemiFinal;
			}
			throw new Exception("Cannot unmarshal type StageName");
		}

		public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
		{
			if (untypedValue == null)
			{
				serializer.Serialize(writer, null);
				return;
			}
			var value = (StageName)untypedValue;
			switch (value)
			{
				case StageName.Final:
					serializer.Serialize(writer, "Final");
					return;
				case StageName.FirstStage:
					serializer.Serialize(writer, "First Stage");
					return;
				case StageName.MatchForThirdPlace:
					serializer.Serialize(writer, "Match for third place");
					return;
				case StageName.QuarterFinal:
					serializer.Serialize(writer, "Quarter-final");
					return;
				case StageName.RoundOf16:
					serializer.Serialize(writer, "Round of 16");
					return;
				case StageName.SemiFinal:
					serializer.Serialize(writer, "Semi-final");
					return;
			}
			throw new Exception("Cannot marshal type StageName");
		}

		public static readonly StageNameConverter Singleton = new StageNameConverter();
	}
}