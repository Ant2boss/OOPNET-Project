using OOPNET_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_DataLayer.Repository
{
	public interface IPlayerRankingsRepo
	{
		PlayerStatistics GetStatisticsForPlayer(string PlayerName, string PlayerImagePath);
	}
}
