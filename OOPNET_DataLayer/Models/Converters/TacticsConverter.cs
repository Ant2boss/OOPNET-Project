using Newtonsoft.Json;
using System;

//Auto-generated using: https://app.quicktype.io/
namespace OOPNET_DataLayer.Models.Converters
{
	internal class TacticsConverter : JsonConverter
	{
		public override bool CanConvert(Type t) => t == typeof(Tactics) || t == typeof(Tactics?);

		public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;
			var value = serializer.Deserialize<string>(reader);
			switch (value)
			{
				case "4-3-3":
					return Tactics.The433;
				case "4-4-2":
					return Tactics.The442;
				case "4-5-1":
					return Tactics.The451;
				case "5-3-2":
					return Tactics.The532;
				case "5-4-1":
					return Tactics.The541;
			}
			throw new Exception("Cannot unmarshal type Tactics");
		}

		public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
		{
			if (untypedValue == null)
			{
				serializer.Serialize(writer, null);
				return;
			}
			var value = (Tactics)untypedValue;
			switch (value)
			{
				case Tactics.The433:
					serializer.Serialize(writer, "4-3-3");
					return;
				case Tactics.The442:
					serializer.Serialize(writer, "4-4-2");
					return;
				case Tactics.The451:
					serializer.Serialize(writer, "4-5-1");
					return;
				case Tactics.The532:
					serializer.Serialize(writer, "5-3-2");
					return;
				case Tactics.The541:
					serializer.Serialize(writer, "5-4-1");
					return;
			}
			throw new Exception("Cannot marshal type Tactics");
		}

		public static readonly TacticsConverter Singleton = new TacticsConverter();
	}
}