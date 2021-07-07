using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNET_DataLayer.Configs
{
	public static class ConfigFilePaths
	{
		public static readonly string LOCAL_REPO_DIR;

		public static readonly string LOCAL_REPO_IMAGES_DIR;
		public static readonly string LOCAL_REPO_JSON_DIR;

		public static readonly string LOCAL_REPO_GLOBAL_CONF_PATH;
		public static readonly string LOCAL_REPO_LOCAL_CONF_PATH;

		private const string _SAME_FOLDER_PREFIX = "./";
		private const string _THREE_BACK_PREFIX = "../../../";

		private const string LOCAL_REPO_DIR_NAME = "LocalRepo";
		private const string IMAGES_DIR_NAME = "Images";
		private const string WORLDCUP_DIR_NAME = "worldcup.sfg.io";
		private const string GLOBAL_FILENAME = "GlobalConfig.txt";
		private const string LOCAL_FILENAME = "LocalConfig.txt";

		static ConfigFilePaths()
		{
			//LocalRepo
			if (Directory.Exists($"{_SAME_FOLDER_PREFIX}{LOCAL_REPO_DIR_NAME}"))
			{
				LOCAL_REPO_DIR = $"{_SAME_FOLDER_PREFIX}{LOCAL_REPO_DIR_NAME}";
			}
			else if (Directory.Exists($"{_THREE_BACK_PREFIX}{LOCAL_REPO_DIR_NAME}"))
			{
				LOCAL_REPO_DIR = $"{_THREE_BACK_PREFIX}{LOCAL_REPO_DIR_NAME}";
			}
			else
			{
				Directory.CreateDirectory($"{_SAME_FOLDER_PREFIX}{LOCAL_REPO_DIR_NAME}");
				LOCAL_REPO_DIR = $"{_SAME_FOLDER_PREFIX}{LOCAL_REPO_DIR_NAME}";
			}

			//LocalRepo/Images
			LOCAL_REPO_IMAGES_DIR = $"{LOCAL_REPO_DIR}/{IMAGES_DIR_NAME}";
			if (!Directory.Exists(LOCAL_REPO_IMAGES_DIR))
			{
				Directory.CreateDirectory(LOCAL_REPO_IMAGES_DIR);
			}

			//LocalRepo/worldcup
			LOCAL_REPO_JSON_DIR = $"{LOCAL_REPO_DIR}/{WORLDCUP_DIR_NAME}";
			if (!Directory.Exists(LOCAL_REPO_JSON_DIR))
			{
				throw new DirectoryNotFoundException($"Unable to find directory: {LOCAL_REPO_JSON_DIR}");
			}

			//LocalRepo/GlobalConfig.txt
			LOCAL_REPO_GLOBAL_CONF_PATH = $"{LOCAL_REPO_DIR}/{GLOBAL_FILENAME}";

			//LocalRepo/LocalConfig.txt
			LOCAL_REPO_LOCAL_CONF_PATH = $"{LOCAL_REPO_DIR}/{LOCAL_FILENAME}";
		}
	}
}
