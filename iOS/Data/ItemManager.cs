using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Bhasvic10th.iOS
{
	public class ItemManager
	{
		
			IRestService restService;

			public ItemManager(IRestService service)
			{
				restService = service;
			}

			public Task<List<TodoItem>> GetTasksAsync()
			{
				return restService.RefreshDataAsync();
			}

		}
	}



