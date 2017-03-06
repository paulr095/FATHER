using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace Bhasvic10th.iOS
{
	public class HomeTableSource : UITableViewSource
	{
		public List<NewsItem> homeItemList;
		string cellidentifiers = "HomeEventCell";

		public HomeTableSource(List<NewsItem> itemList)
		{
			homeItemList = itemList;
			
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			 // defines each cell 
			var cell = tableView.DequeueReusableCell(cellidentifiers);
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellidentifiers);
			}
			cell.TextLabel.Text = homeItemList.ElementAt(indexPath.Row).Name;
			cell.DetailTextLabel.Text = homeItemList.ElementAt(indexPath.Row).Category;
			//categorisedItemList.ElementAt(indexPath.Row).Name
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return homeItemList.Count;

		}
		public NewsItem GetItem(int id)
		{
			return homeItemList.ElementAt(id);
		}
	}
}
