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
		public static readonly string CONFIG_PATH = ConfigFilePaths.LOCAL_REPO_GLOBAL_CONF_PATH;

		public const string CONFK_CULTURE = "Culture";
		public const string CONFK_USE_WEB = "UseWeb";
		public const string CONFK_CUP_TYPE = "CupType";
		public const string CONFK_RESOLUTION = "Resolution";

		public static void CreateEmptyConfigFile()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("--Culutre config--");
			sb.AppendLine($"{CONFK_CULTURE}: \"\"");

			sb.AppendLine("--Cup config--");
			sb.AppendLine($"{CONFK_USE_WEB}: \"true\"");
			sb.AppendLine($"{CONFK_CUP_TYPE}: \"\"");

			sb.AppendLine($"--Visuals config--");
			sb.AppendLine($"{CONFK_RESOLUTION}: \"\"");

			File.WriteAllText(CONFIG_PATH, sb.ToString());
		}
	}
}
