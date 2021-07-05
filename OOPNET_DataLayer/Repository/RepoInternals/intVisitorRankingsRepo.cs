using OOPNET_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_DataLayer.Repository.RepoInternals
{
	internal class intVisitorRankingsRepo : IMatchesVisitorRankingsRepo
	{
		public IList<MatchStatistics> GetMatchStatistics()
		{
			IList<Match> matches = this._MatchesRepo.GetMatchesOfCountry(this._FifaCode);

			IList<MatchStatistics> result = new List<MatchStatistics>();

			foreach (Match match in matches)
			{
				MatchStatistics matchStatistics = new MatchStatistics();

				matchStatistics.Location = match.Location;
				matchStatistics.VisitorCount = match.Attendance;
				matchStatistics.HomeTeam = match.HomeTeam.Country;
				matchStatistics.AwayTeam = match.AwayTeam.Country;

				result.Add(matchStatistics);
			}

			return result;
		}

		public intVisitorRankingsRepo(string FifaCode)
		{
			this._MatchesRepo = RepoFactory.GetMatchesRepo();
			this._FifaCode = FifaCode;
		}

		IMatchesRepo _MatchesRepo;
		string _FifaCode;
	}
}
