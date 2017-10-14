using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Web.Syndication;
using SmplRSS.Models;

namespace SmplRSS.Utility
{
	public static class Rss
	{
		public static async Task<RssFeed> Load(Uri uri)
		{
			var client = new SyndicationClient { BypassCacheOnRetrieve = true };
			try
			{
				var feed = await client.RetrieveFeedAsync(uri);
				var rssFeed = new RssFeed
				{
					Title = $"{feed.Title.Text}({uri.Host})",
					Feeditems = new List<RssFeeditem>(),
					Url = uri.AbsoluteUri
				};
				foreach (var item in feed.Items)
				{
					rssFeed.Feeditems.Add(new RssFeeditem
					{
						Title = item.Title.Text,
						Summary = item.Summary.Text,
						Url = item.Links.First().Uri.AbsoluteUri
					});
				}
				return rssFeed;
			}
			catch (Exception)
			{
				return new RssFeed
				{
					Title = "No Feed",
					Feeditems = new List<RssFeeditem>(),
					Url = uri.AbsoluteUri
				};
			}
		}

		public static async Task<RssFeed> Load(string url)
		{
			try
			{
				return await Load(new Uri(url));
			}
			catch (Exception)
			{
				return new RssFeed
				{
					Title = "No Feed",
					Feeditems = new List<RssFeeditem>(),
					Url = url
				};
			}
		}

		public static async Task<bool> Validate(Uri uri)
		{
			var client = new SyndicationClient { BypassCacheOnRetrieve = true };
			try
			{
				var feed = await client.RetrieveFeedAsync(uri);
				foreach (var syndicationItem in feed.Items)
				{
					
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static async Task<bool> Validate(string url)
		{
			try
			{
				return await Validate(new Uri(url));
			}
			catch (Exception)
			{
				return false;
			}
		}


	}
}
