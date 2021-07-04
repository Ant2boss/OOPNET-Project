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
		public const string LOCAL_CONFIG_PATH = "./LocalRepo/LocalConfig.txt";

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
