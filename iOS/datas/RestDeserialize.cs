using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Bhasvic10th.iOS
{
	public class RestDeserialize
	{
		public List<NewsItem> Items { get; private set; }

		public async Task<List<NewsItem>> RefreshDataAsync()
		{
			HttpClient client = new HttpClient();

			Uri uri = new Uri("https://www.bhasvic.ac.uk/umbraco/api/BHANewsPostservice/getPosts?start=2016-10-11&end=2016-11-11&student=true&public=true");
			string obstring = await client.GetStringAsync(uri);
			List<NewsItem> Items = JsonConvert.DeserializeObject<List<NewsItem>>(obstring);
			Items = new List<NewsItem>();
			return Items;


		}


	}
}
