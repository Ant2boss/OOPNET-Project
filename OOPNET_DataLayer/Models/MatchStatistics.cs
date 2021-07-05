using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_DataLayer.Models
{
	public class MatchStatistics
	{
		public string Location { get; set; }
		public long VisitorCount { get; set; }
		public string HomeTeam { get; set; }
		public string AwayTeam { get; set; }
	}
}
