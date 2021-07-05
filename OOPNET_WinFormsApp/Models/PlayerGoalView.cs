using OOPNET_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_WinFormsApp.Models
{
	public class PlayerGoalView
	{
		public PlayerGoalView(PlayerStatistics stats)
		{
			this.PlayerName = stats.PlayerName;
			this.PlayerImage = stats.PlayerImage;
			this.GoalCount = stats.GoalCount;
		}

		public string PlayerName { get; set; }
		public string PlayerImage { get; set; }
		public int GoalCount { get; set; }

		public static IEnumerable<PlayerGoalView> ListToYellowCardView(IList<PlayerStatistics> playerStatistics)
		{
			foreach (PlayerStatistics ps in playerStatistics)
			{
				yield return new PlayerGoalView(ps);
			}
		}
	}
}
