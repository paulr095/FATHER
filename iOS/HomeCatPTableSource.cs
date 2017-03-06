using System;
using Foundation;
using UIKit;

namespace Bhasvic10th.iOS
{
	public class HomeCatPTableSource : UITableViewSource
	{
		
		public HomeCatPTableSource()
		{
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cellidentifier = "S";
			var cell = tableView.DequeueReusableCell(cellidentifier);
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellidentifier);
			}
			cell.TextLabel.Text = ChosenCategories.categories[indexPath.Row];

			//categorisedItemList.ElementAt(indexPath.Row).Name
			return cell;

		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return ChosenCategories.categories.Length;

		}
	}
}
