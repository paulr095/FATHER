using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Bhasvic10th.iOS
{
	public class NewsItemGrabber
	{
		private string logTag = "";
		private string startDate = "";
		private string endDate = "";
		private HttpClient client = new HttpClient();
		public NewsItemGrabber()
		{
			logTag = "NewsPostGrabber";
			startDate = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");
			endDate = DateTime.Now.ToString("yyyy-MM-dd");
		}
		public async Task<string> getNews()
		{
			string uriString = "https://www.bhasvic.ac.uk/umbraco/api/BHANewsPostservice/getPosts?start=" + startDate + "&end=" + endDate + "&student=true&public=true";
			//string uriString = "https://www.bhasvic.ac.uk/umbraco/api/BHANewsPostservice/getPosts?start=2014-12-31&end=2016-04-29&student=true&public=true";
			Uri uri = new Uri(uriString);
			string jsonString = await client.GetStringAsync(uri);
			return jsonString;
		}

	}
}
