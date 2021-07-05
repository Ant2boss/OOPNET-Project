using OOPNET_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_DataLayer.Repository.RepoInternals
{
	internal class intPlayerRankingsRepo : IPlayerRankingsRepo
	{
		private const string GOAL_EVENT = "goal";
		private const string YELLOW_CARD_EVENT = "yellow-card";

		public PlayerStatistics GetStatisticsForPlayer(string PlayerName, string PlayerImagePath)
		{
			int yellowCardCounter = 0;
			int goalCounter = 0;

			foreach (Match match in this._Matches)
			{
				this._HandleCounters(PlayerName, match.HomeTeamEvents, ref yellowCardCounter, ref goalCounter);
				this._HandleCounters(PlayerName, match.AwayTeamEvents, ref yellowCardCounter, ref goalCounter);
			}

			return new PlayerStatistics(PlayerName, PlayerImagePath, goalCounter, yellowCardCounter);
		}

		public intPlayerRankingsRepo(string FifaCodeFilter)
		{
			this._Matches = RepoFactory.GetMatchesRepo().GetMatchesOfCountry(FifaCodeFilter);
		}

		private IList<Match> _Matches;

		private void _HandleCounters(string PlayerName, IList<MatchTeamEvent> matchTeamEvents, ref int yellowCardCounter, ref int goalCounter)
		{
			foreach (MatchTeamEvent teamEvent in matchTeamEvents)
			{
				if (teamEvent.Player == PlayerName)
				{
					switch (teamEvent.TypeOfEvent)
					{
						case GOAL_EVENT:
							++goalCounter;
							break;
						case YELLOW_CARD_EVENT:
							++yellowCardCounter;
							break;
					}
				}
			}
		}
	}
}
