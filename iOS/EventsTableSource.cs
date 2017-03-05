using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace Bhasvic10th.iOS
{
	public class EventsTableSource : UITableViewSource

	{
		public List<NewsItem> eventItemList;
		string cellidentifier = "EventsCell";// defines each cell 

		public EventsTableSource(List<NewsItem> itemList)
		{
			eventItemList = itemList;

		}


		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			
			var cell = tableView.DequeueReusableCell(cellidentifier);
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellidentifier);
			}
			cell.TextLabel.Text = eventItemList.ElementAt(indexPath.Row).Name;
			cell.DetailTextLabel.Text = eventItemList.ElementAt(indexPath.Row).DateOfEvent;
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return eventItemList.Count;
		}
		public NewsItem GetItem(int id)
		{
			return eventItemList.ElementAt(id);
		}
	}
}
