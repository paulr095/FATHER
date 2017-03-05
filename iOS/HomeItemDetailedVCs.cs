using Foundation;
using System;
using UIKit;
using SafariServices;

namespace Bhasvic10th.iOS
{
	public partial class HomeItemDetailedVCs : UITableViewController
	{
		public HomeItemDetailedVCs(IntPtr handle) : base(handle)
		{
		}

		NewsItem currentNewsItem { get; set; }
		public HomeVC Delegate { get; set; } // will be used to Save, Delete later
		NSUrl url = new NSUrl("https://www.bhasvic.ac.uk");

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

		}

		// this will be called before the view is displayed

		public void SetTask(HomeVC d, NewsItem newsItem)
		//public void SetTask(NewsItem newsItem)
		{
			Delegate = d;
			currentNewsItem = newsItem;
		}
	};
}