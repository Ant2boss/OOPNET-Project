using OOPNET_DataLayer.Models;
using OOPNET_DataLayer.Repository;
using OOPNET_DataLayer.Repository.RepoInternals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPNET_WinFormsApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			ITeamsRepo teamsRepo = RepoFactory.GetTeamsRepo();

			IList<TeamResults> teams = teamsRepo.GetAllTeamResults();
			Console.WriteLine(teams.Count);
		}
	}
}
