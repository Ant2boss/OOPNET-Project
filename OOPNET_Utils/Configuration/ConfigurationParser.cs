using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_Utils.Configuration
{
	public static class ConfigurationParser
	{
		
		/// <exception cref="FileNotFoundException"></exception>
		public static IDictionary<string, string> ParseConfigFile(string FilePath)
		{
			IDictionary<string, string> configDict = new Dictionary<string, string>();

			IList<ConfigurationToken> configTokens = _ParseFileToTokens(FilePath);

			foreach (ConfigurationToken token in configTokens)
			{
				configDict.Add(token.ConfigKey, token.ConfigValue);
			}

			return configDict;
		}

		private static IList<ConfigurationToken> _ParseFileToTokens(string FilePath)
		{
			IList<ConfigurationToken> tokenList = new List<ConfigurationToken>();

			string[] fileLines = File.ReadAllLines(FilePath);
			foreach (string line in fileLines)
			{
				string trimmedLine = line.Trim();

				//Empty or -- lines are ignored
				if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith("--"))
				{
					continue;
				}

				string[] lineParts = trimmedLine.Split(':');

				//Incorrect formating is ignored
				if (lineParts.Length != 2)
				{
					continue;
				}

				ConfigurationToken token = new ConfigurationToken();
				token.ConfigKey = lineParts[0].Trim();
				token.ConfigValue = lineParts[1].Trim();

				//Duplicate keys are ignored
				if (tokenList.Where(t => t.ConfigKey == token.ConfigKey).Count() > 0)
				{
					continue;
				}

				int indexOfFirst = token.ConfigValue.IndexOf('"');
				int indexOfLast = token.ConfigValue.LastIndexOf('"');

				if (indexOfFirst < 0 || indexOfLast == indexOfFirst)
				{
					continue;
				}
				
				token.ConfigValue = token.ConfigValue.Substring(indexOfFirst + 1, indexOfLast - indexOfFirst - 1);

				tokenList.Add(token);
			}

			return tokenList;
		}
	}
}
