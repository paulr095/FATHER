using Foundation;
using System;
using UIKit;
using SafariServices;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Bhasvic10th.iOS
{
	public partial class EventsItemDetailedVCs : UITableViewController
	{
		public EventsItemDetailedVCs(IntPtr handle) : base(handle)
		{
		}
		string cellidentifier = "EventsItemTitle";

		NewsItem currentNewsItem { get; set; }
		public EventsVC Delegate { get; set; } // will be used to Save, Delete later
		//NSUrl url = new NSUrl("https://www.bhasvic.ac.uk");

		public override void ViewWillAppear(bool animated)
		{
			
			base.ViewWillAppear(animated);
			EventsTitleText.Text = currentNewsItem.Name;

			if (currentNewsItem.DateOfEvent == null)
			{
				EventsDateText.Text = "no date";
			}
			else {
				DateTime dt = DateTime.ParseExact(currentNewsItem.DateOfEvent, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
				EventsDateText.Text = dt.ToLongDateString();
			}
			EventsCategoryText.Text = currentNewsItem.Category;

			//EventsDescriptionText.LineBreakMode = UILineBreakMode.WordWrap;
			//EventsDescriptionText.Lines = 0 ;
			string noHTML = Regex.Replace(currentNewsItem.Content, @"<[^>]+>|&nbsp;", "").Trim();
			string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");
			EventsDescriptionText.Text = noHTMLNormalised;



			//safariButton.TouchUpInside += (sender, e) =>
			//{

			//	var sfViewController = new SFSafariViewController(url);

			//	PresentViewController(sfViewController, true, null);
			//};
			//EventTextField.Text = currentNewsItem.Name;
		    //EventDateTextField.Text = currentNewsItem.DateOfEvent;
			//EventDetail.Text = currentNewsItem.Summary;
		}

		// this will be called before the view is displayed

		public void SetTask(EventsVC d, NewsItem newsItem)
		//public void SetTask(NewsItem newsItem)
		{
			Delegate = d;
			currentNewsItem = newsItem;
		}
	};
}