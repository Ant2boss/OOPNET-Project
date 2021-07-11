using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_DataLayer.Models.FavoritePlayers
{
	public class FavoritePlayer
	{
		public FavoritePlayer(MatchPlayer Player)
		{
			this.Player = Player;
		}

		public bool IsFavorite { get; set; }
		public string ImagePath { get; set; }
		public MatchPlayer Player { get; }

		public const char FAVORITE_PLAYERS_DELIM = '|';

		public static FavoritePlayer ParseFileLine(string line, char del)
		{
			string[] lineParts = line.Split(del);

			if (lineParts.Length != 5)
			{
				return null;
			}

			MatchPlayer player = new MatchPlayer();

			player.Name = lineParts[0];
			player.Captain = bool.Parse(lineParts[1]);
			player.ShirtNumber = long.Parse(lineParts[2]);
			player.Position = lineParts[3];

			FavoritePlayer result = new FavoritePlayer(player);

			result.ImagePath = lineParts[4];

			return result;
		}
		public string FormatForFileLine(char del) => $"{this.Player.Name}{del}{this.Player.Captain}{del}{this.Player.ShirtNumber}{del}{this.Player.Position}{del}{this.ImagePath}";

		public override bool Equals(object obj)
		{
			return obj is FavoritePlayer view &&
				   EqualityComparer<MatchPlayer>.Default.Equals(Player, view.Player);
		}
		public override int GetHashCode()
		{
			return -1900088657 + EqualityComparer<MatchPlayer>.Default.GetHashCode(Player);
		}

	}
}
