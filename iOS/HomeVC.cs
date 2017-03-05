using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace Bhasvic10th.iOS
{
	public partial class HomeVC : UITableViewController
	{
		public string ChosenCat = "Geography A Level";

		public HomeVC(IntPtr handle) : base(handle)
		{





		}
		public override void ViewWillAppear(bool animated)
		{
			Console.WriteLine(ChosenCategories.ChosenCategory);
			//TableView.Source = new HomeTableSource(LocalBhasvicDB.getCatItemList(ChosenCategories.ChosenCategory));
			if (ChosenCat == "All")
			{
				TableView.Source = new HomeTableSource(LocalBhasvicDB.getItemList());
			}
			else
			{
				TableView.Source = new HomeTableSource(LocalBhasvicDB.getCatItemList(ChosenCat));
			}
			CatLabel.Text = ChosenCat;
			base.ViewWillAppear(animated);

		}
		public override async void ViewDidLoad()
		{



			base.ViewDidLoad();

			NewsItemGrabber _newsItemGrabber;
			_newsItemGrabber = new NewsItemGrabber();
			LocalBhasvicDB.createNewsItemTable();
			var jsonString = await _newsItemGrabber.getNews();
			Console.WriteLine(jsonString);
			LocalBhasvicDB.updateDBWithJSON(jsonString);
			Console.WriteLine(LocalBhasvicDB.getItemList());


		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "HomeEventsSegue")
			{ // set in Storyboard
				var navctlr = segue.DestinationViewController as HomeItemDetailedVCz;
				if (navctlr != null)
				{
					var source = TableView.Source as HomeTableSource;
					var rowPath = TableView.IndexPathForSelectedRow;
					var item = source.GetItem(rowPath.Row);
					navctlr.SetNewsItem(this, item);

				}
			}
			if (segue.Identifier == "HomeCategoryPickerSegue")
			{ // set in Storyboard
				var navctlr = segue.DestinationViewController as HomeCategoryPicker;
				if (navctlr != null)
				{
					navctlr.SelectCategory(this);
				}
			}
		}
	}
}
