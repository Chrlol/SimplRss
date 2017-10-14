using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using SmplRSS.Models;
using SmplRSS.Utility;

namespace SmplRSS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		public MainPage()
        {
            this.InitializeComponent();

        }
		private async void LoadFeed(Uri url)
		{
			var feed = await Rss.Load(url);
			FeedTitle.Text = feed.Title;
			foreach (var item in feed.Feeditems)
			{
				AddRssItem(item);
			}
		}

	    protected override async void OnNavigatedTo(NavigationEventArgs e)
	    {
		    base.OnNavigatedTo(e);
		    var parameter = e.Parameter as RssFeed;
		    if (parameter != null)
		    {
			    var feed = parameter;
				LoadFeed(new Uri(feed.Url));
		    }
		    else
		    {
				LoadFeed(new Uri("http://www.feedforall.com/sample.xml"));
			}
	    }

	    public void AddRssItem(RssFeeditem item)
		{
			Feed.Items?.Add(new RssItem
			{
				Item = item
			});
		}

	    private async void ChooseFeed_OnTapped(object sender, TappedRoutedEventArgs e)
	    {
		    this.Frame.Navigate(typeof(ChooseFeed), "Hello");
	    }
    }
}
