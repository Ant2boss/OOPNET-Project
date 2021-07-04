using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_DataLayer.Configs
{
	public static class GlobalConfig
	{
		public const string CONFIG_PATH = "./LocalRepo/GlobalConfig.txt";

		public const string CONFK_CULTURE = "Culture";
		public const string CONFK_USE_WEB = "UseWeb";
		public const string CONFK_CUP_TYPE = "CupType";

		public static void CreateEmptyConfigFile()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("--Culutre config--");
			sb.AppendLine($"{CONFK_CULTURE}: \"\"");

			sb.AppendLine("--Representation config--");
			sb.AppendLine($"{CONFK_USE_WEB}: \"true\"");
			sb.AppendLine($"{CONFK_CUP_TYPE}: \"\"");

			File.WriteAllText(CONFIG_PATH, sb.ToString());
		}
	}
}
