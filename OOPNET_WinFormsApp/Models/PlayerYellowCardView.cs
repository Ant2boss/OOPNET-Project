using OOPNET_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_WinFormsApp.Models
{
	public class PlayerYellowCardView
	{
		public PlayerYellowCardView(PlayerStatistics stats)
		{
			this.PlayerName = stats.PlayerName;
			this.PlayerImage = stats.PlayerImage;
			this.YellowCardCount = stats.YellowCardCount;
		}

		public string PlayerName { get; set; }
		public string PlayerImage {get; set; }
		public int YellowCardCount {get; set; }

		public static IEnumerable<PlayerYellowCardView> ListToYellowCardView(IList<PlayerStatistics> playerStatistics)
		{
			foreach (PlayerStatistics ps in playerStatistics)
			{
				yield return new PlayerYellowCardView(ps);
			}
		}
	}
}
