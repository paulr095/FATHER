using Foundation;
using System;
using UIKit;

namespace Bhasvic10th.iOS
{
    public partial class HomeCategoryPicker : UITableViewController
    {
		
		public HomeVC HomeVCDelegate { get; set; } // will be used to Save, Delete later

        public HomeCategoryPicker (IntPtr handle) : base (handle)
        {
			
        }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			TableView.Source = new HomeCatPTableSource();

			if (TableView.IndexPathForSelectedRow != null)
			{
				ChosenCategories.ChosenCategory = ChosenCategories.categories[TableView.IndexPathForSelectedRow.Row];
			}


		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			if (TableView.IndexPathForSelectedRow != null)
			{
				HomeVCDelegate.ChosenCat = ChosenCategories.categories[TableView.IndexPathForSelectedRow.Row];
			}
		}

		public void SelectCategory(HomeVC d)
		{
			HomeVCDelegate = d;
		}

    }
}