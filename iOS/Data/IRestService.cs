using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhasvic10th.iOS
{
	public interface IRestService
	{
		Task<List<TodoItem>> RefreshDataAsync();

	}
}
