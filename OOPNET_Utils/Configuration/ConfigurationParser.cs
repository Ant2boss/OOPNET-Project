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

		public static void UpdateConfigFile(string FilePath, IDictionary<string, string> UpdatedValues)
		{
			string[] fileLines = File.ReadAllLines(FilePath);
			string[] newFileLines = new string[fileLines.Length];

			for (int i = 0; i < fileLines.Length; ++i)
			{
				string line = fileLines[i];

				ConfigurationToken token = _ParseLine(line);

				if (string.IsNullOrEmpty(token.ConfigKey))
				{
					newFileLines[i] = line;
					continue;
				}

				if (UpdatedValues.Keys.Contains(token.ConfigKey))
				{ 
					token.ConfigValue = UpdatedValues[token.ConfigKey];

					newFileLines[i] = token.ToString();
				}
			}

			File.WriteAllLines(FilePath, newFileLines);
		}

		private static IList<ConfigurationToken> _ParseFileToTokens(string FilePath)
		{
			IList<ConfigurationToken> tokenList = new List<ConfigurationToken>();

			string[] fileLines = File.ReadAllLines(FilePath);
			foreach (string line in fileLines)
			{
				ConfigurationToken token = _ParseLine(line);

				if (string.IsNullOrEmpty(token.ConfigKey))
				{
					continue;
				}

				//Duplicate keys are ignored
				if (tokenList.Where(t => t.ConfigKey == token.ConfigKey).Count() > 0)
				{
					continue;
				}

				tokenList.Add(token);
			}

			return tokenList;
		}

		private static ConfigurationToken _ParseLine(string line)
		{
			string trimmedLine = line.Trim();

			//Empty or -- lines are ignored
			if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith("--"))
			{
				return new ConfigurationToken();
			}

			string[] lineParts = trimmedLine.Split(':');

			//Incorrect formating is ignored
			if (lineParts.Length != 2)
			{
				return new ConfigurationToken();
			}

			ConfigurationToken token = new ConfigurationToken();
			token.ConfigKey = lineParts[0].Trim();
			token.ConfigValue = lineParts[1].Trim();

			int indexOfFirst = token.ConfigValue.IndexOf('"');
			int indexOfLast = token.ConfigValue.LastIndexOf('"');

			if (indexOfFirst < 0 || indexOfLast == indexOfFirst)
			{
				return new ConfigurationToken();
			}

			token.ConfigValue = token.ConfigValue.Substring(indexOfFirst + 1, indexOfLast - indexOfFirst - 1);

			return token;
		}

	}
}
