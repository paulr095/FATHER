using System;
using System.Collections.Generic;
using UIKit; // needed to include all of the ui attributes
using System.Linq;
namespace Bhasvic10th.iOS
{
	public class TableSource : UITableViewSource // child of uitableview 
	{
		List<NewsItem> newsItems; //string containing bulletin items data 
	//	UIViewController parentController;
	


		public TableSource(List<NewsItem> items, UIViewController viewController) 
		{
			newsItems = items;
			//_items = items;
			//parentController = viewController;

		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return newsItems.Count;
			//sets rows of table in view to be the same as number of rows of items by overriding rows method
		}

		//public event EventHandler RowBeenSelected;

		public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath )
		{
			//RowBeenSelected(this, EventArgs.Empty);
			/*UIStoryboard storyboard = UIStoryboard.FromName("MainStoryboard", null);
			SecondViewController controller = (UIViewController)storyboard.InstantiateViewController("SecondViewController") as SecondViewController;
			//parentController.PushViewController(controller, true);
			parentController.NavigationController.PushViewController(controller, true);*/

		}

	public override  UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			
			string cellidentifier = "tablecell"; // defines each cell 
			UITableViewCell cell = tableView.DequeueReusableCell(cellidentifier); //recycles cell memory 
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellidentifier);
			}
			//produces a cell in a default style
			//cell.ContentView.BackgroundColor = UIColor.DarkGray;
			cell.TextLabel.Text = newsItems.ElementAt(indexPath.Row).Name;

			return cell;
		
		}

	}
}
