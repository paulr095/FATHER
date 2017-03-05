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
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading.Tasks;

namespace Bhasvic10th.iOS
{

	public partial class ItemDetailedViewController : UIViewController
	{


		UIStackView StackView;
		//public string name { get;  set; }
		//	public string date { get; set; }
		//	public string content { get; set; }
		//	public string url { get; set; }
		public NewsItem NewsItem { get; set; }
		public ItemDetailedViewController(IntPtr handle) : base(handle)
		{

		}

	

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();



			StackView = new UIStackView();



			var titleLabel = new UILabel(new CGRect(10, 20, View.Bounds.Width - 10, 30));
			titleLabel.Text = "BHASVIC";
			titleLabel.Font = UIFont.BoldSystemFontOfSize(25);
			StackView.AddArrangedSubview(titleLabel);

			var nameLabel = new UILabel(new CGRect(10, 0, View.Bounds.Width - 10, 200));
			nameLabel.Text = NewsItem.Name;
			nameLabel.Lines = 0;
			nameLabel.Font = UIFont.BoldSystemFontOfSize(30);
			nameLabel.LineBreakMode = UILineBreakMode.WordWrap;
			StackView.AddArrangedSubview(nameLabel);

			var dateLabel = new UILabel(new CGRect(10, 100, View.Bounds.Width - 10, 30));
			DateTime dt = DateTime.ParseExact(NewsItem.DatePublished, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
			dateLabel.Text = dt.ToShortDateString();
			StackView.AddArrangedSubview(dateLabel);

			var contentLabel = new UILabel(new CGRect(10, 120, View.Bounds.Width - 20, 300));
			string noHTML = Regex.Replace(NewsItem.Content, @"<[^>]+>|&nbsp;", "").Trim();
			string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");
			contentLabel.Text = noHTMLNormalised;
			contentLabel.Lines = 0;
			contentLabel.LineBreakMode = UILineBreakMode.WordWrap;
			StackView.AddArrangedSubview(contentLabel);

			var dateoELabel = new UILabel(new CGRect(10, 80, View.Bounds.Width - 10, 30));
			//DateTime dtt = DateTime.ParseExact(NewsItem.DateOfEvent, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
			dateLabel.Text = NewsItem.DateOfEvent;
			Console.WriteLine(NewsItem.DateOfEvent);

			StackView.AddArrangedSubview(dateoELabel);


			var dateNLabel = new UILabel(new CGRect(10, 130, View.Bounds.Width - 10, 30));
			//DateTime dtt = DateTime.ParseExact(NewsItem.DateOfEvent, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
			dateLabel.Text = NewsItem.NotificationDate;
			Console.WriteLine(NewsItem.NotificationDate);
			StackView.AddArrangedSubview(dateNLabel);





			//var image = new UIImage();
			////image = this.LoadImage("some image url");
			//var imageView = new UIImageView();
			//imageView.Image = image;
			//View.AddSubview(imageView);


			//var categoryLabel = new UILabel(new CGRect(10, 80, View.Bounds.Width, 30));
			////DateTime dtt = DateTime.ParseExact(NewsItem.DateOfEvent, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
			//dateLabel.Text = NewsItem.Category;
			//scrollView.AddSubview(categoryLabel);



			View.AddSubview(StackView);


		//	NavigationController.SetHasNavigationBar(this, false);
			//this.NavigationController.PopToRootViewController(true);





		}
		public async Task<UIImage> LoadImage(string imageUrl)
		{
			var httpClient = new HttpClient();

			Task<byte[]> contentsTask = httpClient.GetByteArrayAsync(imageUrl);

			// await! control returns to the caller and the task continues to run on another thread
			var contents = await contentsTask;

			// load from bytes
			return UIImage.LoadFromData(NSData.FromArray(contents));
		}

		//public override void ViewDidLayoutSubviews()
		//{
			
		//	scrollView.Frame = new CoreGraphics.CGRect(0, 0, this.View.Bounds.Size.Width, 500);
		//	scrollView.ContentSize = scrollView.Frame.Size; // This may not be what you actually want, but what you had before was certainly wrong.
		////	scrollView.titleLabel.Frame = new CoreGraphics.CGRect(0, 0, this.View.Bounds.Size.Width, this.View.Bounds.Size.Height);
		////}

    }
}