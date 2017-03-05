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

namespace Bhasvic10th.iOS
{

	public partial class CategoriesController : UIViewController, IUITableViewDelegate, IUITableViewDataSource
	{
		UIViewController SecondViewController;
		List<NewsItem> itemList;




		public CategoriesController(IntPtr handle) : base(handle)
		{


		}
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


			if (RestorationIdentifier == "ViewController1")
			{


			}



			var titleLabel = new UILabel(new CGRect(10, 20, View.Bounds.Width - 10, 30));
			titleLabel.Text = "BHASVIC";
			titleLabel.Font = UIFont.BoldSystemFontOfSize(20);
			titleLabel.TextColor = UIColor.LightTextColor;
			View.AddSubview(titleLabel);

			var mainLabel = UIButton.FromType(UIButtonType.RoundedRect);
			mainLabel.Frame = new CGRect(View.Frame.Right - 75, 20, View.Bounds.Width - 10, 30);
			mainLabel.SetTitle("GENERAL", UIControlState.Normal);
			mainLabel.Font = UIFont.BoldSystemFontOfSize(20);
			mainLabel.SetTitleColor(UIColor.FromRGB(250, 209, 124), UIControlState.Normal);
	
			View.AddSubview(mainLabel);

				



				HttpClient client = new HttpClient();

		string startDate = DateTime.Now.ToString("yyyy-MM-dd");
		string endDate = DateTime.Now.ToString("yyyy-MM-dd");


		Console.WriteLine(startDate);
				Console.WriteLine(endDate);
				string uriString = "https://www.bhasvic.ac.uk/umbraco/api/BHANewsPostservice/getPosts?start=" + startDate + "&end=" + endDate + "&student=true&public=true";

		Uri uri = new Uri(uriString);
		string jsonString = await client.GetStringAsync(uri);
		Console.WriteLine(jsonString);
				itemList = JsonConvert.DeserializeObject<List<NewsItem>>(jsonString);

			//button.SetTitle("hello", UIControlState.Normal);
			//View.Add(button);
			//button.TouchUpInside += (sender, e) =>
			//{
			//	SecondViewController controller = this.Storyboard.InstantiateViewController("SecondViewController") as SecondViewController;
			//	controller.name = itemList.First().Name;
			//	this.NavigationController.PushViewController(controller, true);


			//}
			//;

			/*string dbPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ormdemo.db3");
			var db = new SQLiteConnection(dbPath);
			db.CreateTable<RootClass>();
			//	db.Insert(bulletinOb);


				var table = db.Table<RootClass>();
				foreach (var s in table)
				{
					Console.WriteLine(s.Name + " " + s.DatePublished);
				}


			//foreach (Array bulletinOb in RootClass) { 
			//}
		//	RootClass p1 = bulletinOb[0];
		//	RootClass p2 = bulletinOb[1];
		//	RootClass p3 = bulletinOb[2];
			RootClass p4 = bulletinOb[3];
			RootClass p5 = bulletinOb[4];
*/

			// Perform any additional setup after loading the view, typically from a nib.

			//	Console.WriteLine(itemList[0].Name);



			//	testItem.LineBreakMode = UILineBreakMode.CharacterWrap;
			//	View.AddSubview(testItem);
			//bulletinText.text = bulletin.Name.bulletin;


			/*int i;
			string[] data = new string[itemList.Count];
			for (i = 0; i < itemList.Count; i++) {
				data[i] = itemList[i].Name;
			}*/



			//	string[] data = new string[] {"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa","b" ,"c" ,"d" ,"e" };
			//create table view



			if (itemList.Count > 0)
			{
				UITableView _table;
		_table = new UITableView
				{
					Frame = new CGRect(0, 50, View.Bounds.Width, View.Bounds.Height - 100),
					//	Source = new TableSource(itemList, NavigationController)

				};
	//TableSource source = new TableSource(itemList, NavigationController);
	//source.RowBeenSelected += handleRowBeenSelected;
	_table.WeakDataSource = this;
				_table.WeakDelegate = this;



	View.AddSubview(_table);

	}
			else {
				var frame = new CGRect(0, 50, View.Bounds.Width, View.Bounds.Height - 100);
	var novalueLabel = new UILabel(new CGRect(10, 100, View.Bounds.Width, 30));
	novalueLabel.Text = "There are no new items today";
				novalueLabel.Font = UIFont.BoldSystemFontOfSize(35);
				novalueLabel.TextColor = UIColor.LightTextColor;

				View.AddSubview(novalueLabel);

			}




			}



			//	public void handleRowBeenSelected(object sender, EventArgs e) { 

			//SecondViewController controller = this.Storyboard.InstantiateViewController("SecondViewController") as SecondViewController;
			//	this.NavigationController.PushViewController(controller, true);

			//	}
			//






			public override void DidReceiveMemoryWarning()
{
	base.DidReceiveMemoryWarning();
	// Release any cached data, images, etc that aren't in use.		
}




public nint RowsInSection(UITableView tableView, nint section)
{
	//SecondViewController controller = this.Storyboard.InstantiateViewController("SecondViewController") as SecondViewController;
	//this.NavigationController.PushViewController(controller, true);
	return itemList.Count;
}



[Export("tableView:didSelectRowAtIndexPath:")]
public void RowSelected(UITableView tableView, NSIndexPath indexPath)
{
	ItemDetailedViewController controller = this.Storyboard.InstantiateViewController("SecondViewController") as ItemDetailedViewController;
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
	//produces a cell in a default style
	//cell.ContentView.BackgroundColor = UIColor.DarkGray;
	if (itemList.Count == 0)
	{
		cell.TextLabel.Text = "there are no more items to show";
	}
	else
	{
		cell.TextLabel.Text = itemList.ElementAt(indexPath.Row).Name;
	}
	return cell;




}

		}
	
	
	
	
	
	
	
	
	}


