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
    public partial class EventsItemDetailedVC : UIViewController
    {
        public EventsItemDetailedVC (IntPtr handle) : base (handle)
        {
			
        }
				UIStackView StackView;
		//public string name { get;  set; }
		//	public string date { get; set; }
		//	public string content { get; set; }
		//	public string url { get; set; }
		public NewsItem NewsItem { get; set; }


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}






		//public override void ViewDidLayoutSubviews()
		//{

		//	scrollView.Frame = new CoreGraphics.CGRect(0, 0, this.View.Bounds.Size.Width, 500);
		//	scrollView.ContentSize = scrollView.Frame.Size; // This may not be what you actually want, but what you had before was certainly wrong.
		////	scrollView.titleLabel.Frame = new CoreGraphics.CGRect(0, 0, this.View.Bounds.Size.Width, this.View.Bounds.Size.Height);
		////}

	}
  }
