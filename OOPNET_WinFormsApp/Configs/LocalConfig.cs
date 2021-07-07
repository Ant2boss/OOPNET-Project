using OOPNET_DataLayer.Configs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_WinFormsApp.Configs
{
	public static class LocalConfig
	{
		public static readonly string LOCAL_CONFIG_PATH = ConfigFilePaths.LOCAL_REPO_LOCAL_CONF_PATH;

		public const string CONFK_FAVORITE_REPRESENT = "FavoriteRepresentation";

		public static void CreateEmptyConfigFile()
		{
			StringBuilder sbUser = new StringBuilder();

			sbUser.AppendLine("--User settings--");
			sbUser.AppendLine($"{CONFK_FAVORITE_REPRESENT}: \"\"");

			File.WriteAllText(LOCAL_CONFIG_PATH, sbUser.ToString());
		}
	}
}
