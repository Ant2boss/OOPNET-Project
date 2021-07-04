﻿using OOPNET_DataLayer.Configs;
using OOPNET_DataLayer.Models;
using OOPNET_DataLayer.Repository;
using OOPNET_DataLayer.Repository.RepoInternals;
using OOPNET_Utils.Configuration;
using OOPNET_WinFormsApp.Configs;
using OOPNET_WinFormsApp.Initializations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPNET_WinFormsApp
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			if (!this._InitSettings())
			{
				MessageBox.Show("Inital setup not completed!", "Error");
				this.Dispose();
			}

			InitializeComponent();

			this._InitForm();

			this.CenterToScreen();
		}

		private const string CONFIG_FILE_PATH = GlobalConfig.CONFIG_PATH;
		private const string USER_CONFIG_FILE_PATH = LocalConfig.LOCAL_CONFIG_PATH;

		private const string CONFK_CULTURE = GlobalConfig.CONFK_CULTURE;
		private const string CONFK_CUP_TYPE = GlobalConfig.CONFK_CUP_TYPE;

		private const string CONFK_FAVORITE = LocalConfig.CONFK_FAVORITE_REPRESENT;

		private IList<MatchStartingEleven> _Players;

		private bool _InitSettings()
		{
			if (!_InitCupTypeAndCulture())
			{
				return false;
			}

			IDictionary<string, string> config = ConfigurationParser.ParseConfigFile(CONFIG_FILE_PATH);

			Thread.CurrentThread.CurrentCulture = new CultureInfo(config[CONFK_CULTURE]);
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(config[CONFK_CULTURE]);

			return true;
		}
		private bool _InitCupTypeAndCulture()
		{
			try
			{
				//Try to open file
				IDictionary<string, string> config = ConfigurationParser.ParseConfigFile(CONFIG_FILE_PATH);

				//Check the two settings if they are empty
				if (string.IsNullOrEmpty(config[CONFK_CULTURE]) || string.IsNullOrEmpty(config[CONFK_CUP_TYPE]))
				{
					//Get the information from the Chooser
					RepresentationChooser repChooser = new RepresentationChooser();
					if (repChooser.ShowDialog() == DialogResult.OK)
					{
						config[CONFK_CULTURE] = repChooser.GetCulture();
						config[CONFK_CUP_TYPE] = repChooser.GetCupType();

						//Update information
						ConfigurationParser.UpdateConfigFile(CONFIG_FILE_PATH, config);
					}
					else
					{
						return false;
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				if (ex is FileNotFoundException || ex is KeyNotFoundException)
				{ 
					MessageBox.Show("Error reading config, creating new config file!", "Error");
					GlobalConfig.CreateEmptyConfigFile();
					LocalConfig.CreateEmptyConfigFile();
					return this._InitCupTypeAndCulture();
				}

				throw;
			}
		}

		private void _InitForm()
		{
			IList<Team> teams = RepoFactory.GetTeamsRepo().GetAllTeams();

			teams.ToList().ForEach(t => this.cbTeams.Items.Add(t));

			IDictionary<string, string> config = ConfigurationParser.ParseConfigFile(USER_CONFIG_FILE_PATH);

			if (!string.IsNullOrEmpty(config[CONFK_FAVORITE]))
			{
				string favTeamCode = config[CONFK_FAVORITE];
				Team favoriteTeam = teams.First(t => t.FifaCode == favTeamCode);

				this.cbTeams.SelectedItem = favoriteTeam;
			}
		}

		private void cbTeams_SelectedIndexChanged(object sender, EventArgs e)
		{
			IDictionary<string, string> config = ConfigurationParser.ParseConfigFile(USER_CONFIG_FILE_PATH);
			config[CONFK_FAVORITE] = (this.cbTeams.SelectedItem as Team).FifaCode;
			ConfigurationParser.UpdateConfigFile(USER_CONFIG_FILE_PATH, config);

			this._UpdateTeamPlayers(config[CONFK_FAVORITE]);
		}

		private void _UpdateTeamPlayers(string FifaCode)
		{
			IMatchesRepo matchesRepo = RepoFactory.GetMatchesRepo();

			Match firstMatchOfTeam = matchesRepo.GetMatchesOfCountry(FifaCode).First();

			if (firstMatchOfTeam.HomeTeam.Code == FifaCode)
			{
				this._Players = new List<MatchStartingEleven>(firstMatchOfTeam.HomeTeamStatistics.StartingEleven.Union(firstMatchOfTeam.HomeTeamStatistics.Substitutes));
			}
			else
			{ 
				this._Players = new List<MatchStartingEleven>(firstMatchOfTeam.AwayTeamStatistics.StartingEleven.Union(firstMatchOfTeam.AwayTeamStatistics.Substitutes));
			}
		}
	}
}
