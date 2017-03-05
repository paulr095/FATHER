using System;
using Newtonsoft.Json;

namespace Bhasvic10th.iOS
{

	public static List<RootObject> Deserialize<RootObject>(this string obstring)
	{
		var bulletinOb = JsonConvert.DeserializeObject<List<RootObject>>(obstring);
		return bulletinOb;
		//
		//return 
	};

}
