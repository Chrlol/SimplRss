using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using SmplRSS.Models;
using SmplRSS.Utility;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SmplRSS
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class ChooseFeed : Page
    {
        public ChooseFeed()
        {
            this.InitializeComponent();
        }

	    protected override async void OnNavigatedTo(NavigationEventArgs e)
	    {
		    base.OnNavigatedTo(e);

		    var feeds = await Storage.GetFeeds();
			foreach (var item in feeds)
			{
				Feed.Items?.Add(new FeedItem
				{
					Feed = item
				});
			}
		}

		private void Back(object sender, RoutedEventArgs e)
		{
			this.Frame.GoBack();
		}

		private async void FromClipholder_Click(object sender, RoutedEventArgs e)
		{
			var p = Clipboard.GetContent();
			var content = await p.GetTextAsync();
			Log.Text += Environment.NewLine + content;

			var feed = new RssFeed
			{
				Title = content,
				Url = content
			};
			Storage.SaveFeed(feed);
		}
	}
}
