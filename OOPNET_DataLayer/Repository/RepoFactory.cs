using OOPNET_DataLayer.Configs;
using OOPNET_DataLayer.Repository.RepoInternals;
using OOPNET_Utils.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_DataLayer.Repository
{
	public enum CupType { MaleCup, FemaleCup };

	public static class RepoFactory
	{
		private static readonly bool IS_ONLINE;
		private static readonly bool IS_FEMALE_CUP;

		static RepoFactory()
		{
			IDictionary<string, string> config = ConfigurationParser.ParseConfigFile(GlobalConfig.CONFIG_PATH);

			IS_ONLINE = bool.Parse(config[GlobalConfig.CONFK_USE_WEB]);
			IS_FEMALE_CUP = config[GlobalConfig.CONFK_CUP_TYPE].Equals(CupType.FemaleCup.ToString());
		}

		public static ITeamsRepo GetTeamsRepo()
		{
			if (IS_ONLINE)
			{
				return new intWebTeamsRepo(_GetCupType());
			}
			else
			{
				return new intLocalTeamsRepo(_GetCupType());
			}
		}

		public static IMatchesRepo GetMatchesRepo()
		{
			if (IS_ONLINE)
			{
				return new intWebMatchesRepo(_GetCupType());
			}
			else
			{
				return new intLocalMatchesRepo(_GetCupType());
			}
		}

		private static CupType _GetCupType() => (IS_FEMALE_CUP) ? (CupType.FemaleCup) : (CupType.MaleCup);
	}
}
