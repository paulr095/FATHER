using System;
using CoreGraphics;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using SQLite;
using UIKit;
using Foundation;
using System.Linq;
using CoreAnimation;
using System.Drawing;
namespace Bhasvic10th.iOS
{
    public partial class EventsViewController : UIViewController, IUITableViewDelegate, IUITableViewDataSource
    {
        public EventsViewController (IntPtr handle) : base (handle)
        {
        }




		UIViewController HomeItemDetailedVC;
		List<NewsItem> itemList;
		List<NewsItem> categorisedItemList;


		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			this.NavigationController.SetNavigationBarHidden(true, animated);
		}
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			this.NavigationController.SetNavigationBarHidden(false, animated);
		}




		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();




			var selectedtab = "Economics, Business & Acc";

			View.BackgroundColor = UIColor.FromRGB(13, 13, 13);


			//creates BhasvicTitle 
			var titleLabel = new UILabel(new CGRect(10, 20, View.Bounds.Width - 10, 30));
			titleLabel.Text = "BHASVIC";
			titleLabel.Font = UIFont.BoldSystemFontOfSize(20);
			titleLabel.TextColor = UIColor.LightTextColor;
			View.AddSubview(titleLabel);

			var homeButton = UIButton.FromType(UIButtonType.System);
			homeButton.Frame = new CGRect(100, 20, View.Bounds.Width - 10, 30);
			homeButton.SetTitle("HOME", UIControlState.Normal);
			View.AddSubview(homeButton);










			HttpClient client = new HttpClient();

			string startDate = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");
			string endDate = DateTime.Now.ToString("yyyy-MM-dd");


			Console.WriteLine(startDate);
			Console.WriteLine(endDate);
			string uriString = "https://www.bhasvic.ac.uk/umbraco/api/BHANewsPostservice/getPosts?start=" + startDate + "&end=" + endDate + "&student=true&public=false";




			Uri uri = new Uri(uriString);
			string jsonString = await client.GetStringAsync(uri);
			//var filename = Path.Combine(documents, "account.json");
			//ile.WriteAllText(filename, jsonString);

			//Console.WriteLine(jsonString);
			itemList = JsonConvert.DeserializeObject<List<NewsItem>>(jsonString);
			categorisedItemList = JsonConvert.DeserializeObject<List<NewsItem>>(jsonString);
			//categorisedItemList.AddRange(itemList);
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var _pathToDatabase = Path.Combine(documents, "db_sqlite-net.db");




			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine(documentsPath, "../Library/");
			var path = Path.Combine(libraryPath, "MyDatabase.db3");
			Console.WriteLine(path);

			var db = new SQLite.SQLiteConnection(path);

			db.CreateTable<NewsItem>();



			db.RunInTransaction(() =>
			{
				foreach (var item in itemList)
				{
					db.InsertOrReplace(item);
				}

			});
			//todo, create a new table after select period of time and omit old data




			var query = db.Table<NewsItem>().Where(v => v.Category.Equals("General"));

			foreach (var category in query)
			{
				Console.WriteLine("Category: " + category.Name);
			}

			//	var query = db.Query<NewsItem>("select * from NewsItem where Category = 'General'");
			//	Console.WriteLine(query.ToString());




			Console.WriteLine(categorisedItemList.ElementAt(0).Category);





			UITableView _table;
			_table = new UITableView
			{
				Frame = new CGRect(-10, 60, View.Bounds.Width, (categorisedItemList.Count * 45)),
				BackgroundColor = UIColor.FromRGB(24, 24, 24)   //	Source = new TableSource(itemList, NavigationController)

			};


			_table.WeakDataSource = this;
			_table.WeakDelegate = this;
			View.AddSubview(_table);
		}










		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}






		public nint RowsInSection(UITableView tableView, nint section)
		{

			int n = 0;
			int tablecount = categorisedItemList.Count;
			Console.WriteLine(tablecount);
			while (n == 0)
			{
				if (categorisedItemList.ElementAt(tablecount - 1).ToString() == "")
				{
					tablecount = tablecount - 1;
				}
				else {
					return tablecount;
				}
			}
			return tablecount;

		}


		[Export("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			EventsItemDetailedVC controller = this.Storyboard.InstantiateViewController("EventsItemDetailedVC") as EventsItemDetailedVC;
			///		controller.name = itemList.ElementAt(indexPath.Row).Name;
			//		controller.date = itemList.ElementAt(indexPath.Row).DatePublished;
			//		controller.content = itemList.ElementAt(indexPath.Row).Content;
			//		controller.url = itemList.ElementAt(indexPath.Row).Url;

			controller.NewsItem = itemList.ElementAt(indexPath.Row);
			this.NavigationController.PushViewController(controller, true);


		}

		public UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{

			string cellidentifier = "tablecell"; // defines each cell 
			UITableViewCell cell = tableView.DequeueReusableCell(cellidentifier); //recycles cell memory 
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellidentifier);
			}

			if (indexPath.Row % 2 == 0)
			{
				cell.BackgroundColor = UIColor.FromRGB(25, 25, 25);

			}
			else {
				cell.BackgroundColor = UIColor.FromRGB(22, 22, 22);

			}
			//produces a cell in a default style
			//cell.ContentView.BackgroundColor = UIColor.DarkGray;
			cell.TextLabel.TextColor = UIColor.LightTextColor;

			cell.TextLabel.Text = categorisedItemList.ElementAt(indexPath.Row).Name;

			return cell;


		}

		//public nint GetComponentCount(UIPickerView pickerView)
		//{
		//	throw new NotImplementedException();
		//}

		public nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			throw new NotImplementedException();
		}

		//[Export("pickerView:titleForRow:forComponent:")]
		//public string GetTitle(UIPickerView pickerView, nint row, nint component)
		//{
		//	return "Component " + row.ToString();
		//}
		//} 



	}


}



