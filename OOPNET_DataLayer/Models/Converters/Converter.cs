using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

//Auto-generated using: https://app.quicktype.io/
namespace OOPNET_DataLayer.Models.Converters
{
	internal static class Converter
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Converters =
			{
				new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
			},
		};
	}
}
