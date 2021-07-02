using OOPNET_DataLayer.Repository.RepoInternals;
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
		private static readonly bool IS_ONLINE = true;
		private static readonly bool IS_FEMALE_CUP = true;

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
