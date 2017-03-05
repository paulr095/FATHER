using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace Bhasvic10th.iOS
{
	public class EventsItemDetailedTableSource: UITableViewSource
	{

		public List<NewsItem> eventItemList;
		string Titlecellidentifier = "EventsItemTitle";
		string Datecellidentifier = "EventsItemDate";
		string Descriptioncellidentifier = "EventsItemDescription";
		string Categorycellidentifier = "EventsItemCategory";
		string Imagecellidentifier = "EventsItemImage";// defines each cell 
		int rowid;

		public EventsItemDetailedTableSource(List<NewsItem> itemList)
		{
			eventItemList = itemList;
			
		}




		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{

			var titlecell = tableView.DequeueReusableCell(Titlecellidentifier);

			if (titlecell == null)
			{
				titlecell = new UITableViewCell(UITableViewCellStyle.Default, Titlecellidentifier);
			}
			titlecell.TextLabel.Text = eventItemList.ElementAt(indexPath.Row).Name;
			//categorisedItemList.ElementAt(indexPath.Row).Name


			Console.WriteLine(indexPath);
			return titlecell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return 5;
		}
		public NewsItem GetItem(int id)
		{
			return eventItemList.ElementAt(id);
		}
	}
}
