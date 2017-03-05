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
	public partial class ViewControllerSettings : UIViewController, IUITableViewDelegate
	{


		public ViewControllerSettings(IntPtr handle) : base(handle)
		{
			//creates BhasvicTitle 
			var titleLabel = new UILabel(new CGRect(10, 20, View.Bounds.Width - 10, 30));
			titleLabel.Text = "BHASVIC";
			titleLabel.Font = UIFont.BoldSystemFontOfSize(25);
			View.AddSubview(titleLabel);

			// creates Settings title 
			var settingsLabel = new UILabel(new CGRect(50, 20, View.Bounds.Width - 50, 30));
			titleLabel.Text = "Settings";
			titleLabel.Font = UIFont.BoldSystemFontOfSize(25);
			View.AddSubview(settingsLabel);


			UITableView table = new UITableView(View.Bounds, UITableViewStyle.Grouped);
			table.WeakDataSource = this;
			table.WeakDelegate = this;






		}







	}
}
