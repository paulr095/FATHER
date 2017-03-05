using Foundation;
using System;
using UIKit;

namespace Bhasvic10th.iOS
{
    public partial class secondViewController : UIViewController
    {
        public secondViewController (IntPtr handle) : base (handle)
        {


        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var titleLabel = new UILabel(new CGRect(10, 20, View.Bounds.Width, 30));
			titleLabel.Text = "BHASVIC Second view";
			View.AddSubview(titleLabel);
		}
    }
}