using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_DataLayer.ConfigurationManager
{
	public static class DAL_ApplicationConfig
	{
		public const string CONFIG_PATH = "./LocalRepo/AppConfig.txt";

		public static void CreateEmptyConfigFile()
		{
			File.WriteAllText(CONFIG_PATH,
				"--Culture config--\n" +
				"Culture: \"\"\n" +
				"--Representation config--\n" +
				"CupType: \"\""
				);
		}
	}
}
