using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using SmplRSS.Models;

namespace SmplRSS.Utility
{
	public static class Storage
	{
		public static StorageFolder StorageFolder { get; } = ApplicationData.Current.LocalFolder;
		private const string FileName = "SimplRssData.json";

		public static async void SaveFeed(RssFeed feed)
		{
			var feeds = await GetFeeds();
			var isValid = await Rss.Validate(feed.Url);
			if(isValid)
				feeds.Add(feed);

			var serialized = JsonConvert.SerializeObject(feeds);
			var file = await StorageFolder.CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);
			if (serialized != null)
				await FileIO.WriteTextAsync(file, serialized);
		}

		public static async Task<List<RssFeed>> GetFeeds()
		{
			try
			{
				var file = await StorageFolder.GetFileAsync(FileName);
				var fileContent = await FileIO.ReadTextAsync(file);
				var feeds = JsonConvert.DeserializeObject<List<RssFeed>>(fileContent);
				return feeds;
			}
			catch (Exception)
			{
				return new List<RssFeed>();
			}
		}

	}
}
