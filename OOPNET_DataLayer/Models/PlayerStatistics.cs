using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_DataLayer.Models
{
	public class PlayerStatistics
	{
		public PlayerStatistics(string playerName, string playerImage, int goalCount, int yellowCardCount)
		{
			PlayerName = playerName;
			PlayerImage = playerImage;
			GoalCount = goalCount;
			YellowCardCount = yellowCardCount;
		}

		public string PlayerName { get; }
		public string PlayerImage { get; }

		public int GoalCount { get; }
		public int YellowCardCount { get; }
	}
}
