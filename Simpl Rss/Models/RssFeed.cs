using System.Collections.Generic;

namespace SmplRSS.Models
{
	public class RssFeed
	{
		public string Title { get; set; }
		public string Url { get; set; }
		public List<RssFeeditem> Feeditems { get; set; }
	}
}
