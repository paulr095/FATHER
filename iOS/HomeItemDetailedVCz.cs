using Foundation;
using System;
using UIKit;
using SafariServices;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Bhasvic10th.iOS
{
	public partial class HomeItemDetailedVCz : UITableViewController
	{
		public HomeItemDetailedVCz(IntPtr handle) : base(handle)
		{
		}

		NewsItem currentNewsItem { get; set; }
		public HomeVC Delegate { get; set; } // will be used to Save, Delete later
		NSUrl url = new NSUrl("https://www.bhasvic.ac.uk");

		public override void ViewWillAppear(bool animated)
		{
			
			base.ViewWillAppear(animated);
			HomeTitleText.Text = currentNewsItem.Name;

			if (currentNewsItem.DateOfEvent == null)
			{
				HomeDateText.Text = "no date";
			}
			else {
				DateTime dt = DateTime.ParseExact(currentNewsItem.DateOfEvent, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
				HomeDateText.Text = dt.ToLongDateString();
			}
			HomeCategoryText.Text = currentNewsItem.Category;

			//EventsDescriptionText.LineBreakMode = UILineBreakMode.WordWrap;
			//EventsDescriptionText.Lines = 0 ;
			string noHTML = Regex.Replace(currentNewsItem.Content, @"<[^>]+>|&nbsp;", "").Trim();
			string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");
			HomeDescriptionText.Text = noHTMLNormalised;

		}

		// this will be called before the view is displayed

		public void SetNewsItem(HomeVC d, NewsItem newsItem)
		//public void SetTask(NewsItem newsItem)
		{
			Delegate = d;
			currentNewsItem = newsItem;
		}
	};
}