using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;
using System.Linq;
using UIKit;
using System.Text;
using System.IO;
namespace Bhasvic10th.iOS
{
	public static class LocalBhasvicDB
	{
		public static string logTag { get; set; }
		public static string DBLocation { get; set; }
		public static string documentsPath { get; set; }
		public static string libraryPath { get; set; }
		public static List<NewsItem> itemList;
		public static List<NewsItem> categorisedItemList;
		public static SQLite.SQLiteConnection db;

		static LocalBhasvicDB()
		{

			logTag = "LocalBhasvicDB";
			documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			libraryPath = Path.Combine(documentsPath, "../Library/");
			DBLocation = Path.Combine(libraryPath, "NewsItemDB.db3");
			db = new SQLite.SQLiteConnection(DBLocation);
			Console.WriteLine(db);
			Console.WriteLine(DBLocation);



		}

		static public void createNewsItemTable()
		{
			
			db.CreateTable<NewsItem>();
			//return true;
		}

		static public void createSettingsItemTable()
		{
			db.CreateTable<SystemSettings>();
			//db.CreateTable<ChosenCategories>();
			//return true;
		}

		static public bool updateDBWithJSON(string jsonString)
		{
			//Console.WriteLine("jsonString: " + jsonString);
			itemList = JsonConvert.DeserializeObject<List<NewsItem>>(jsonString);
			//categorisedItemList = JsonConvert.DeserializeObject<List<NewsItem>>(jsonString);
			//categorisedItemList.AddRange(itemList);
			db.RunInTransaction(() =>
			{
				foreach (var item in itemList)
				{
					db.InsertOrReplace(item);
				}

			});
			return true;
		}

		static public List<NewsItem> getItemList()
		{
			//var query = db.Table<NewsItem>().Select(res => res);
			var query = db.Query<NewsItem>("select * from NewsItem");
			return query.ToList();
		}
		static public List<NewsItem> getCatItemList(string chosenCat)
		{
			var query2 = db.Query<NewsItem>("select * from NewsItem where Category = '" + chosenCat + "'");
			return query2.ToList();
		
		}

	}
}