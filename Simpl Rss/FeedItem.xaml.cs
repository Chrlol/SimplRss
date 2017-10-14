using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SmplRSS.Models;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SmplRSS
{
	public sealed partial class FeedItem : UserControl
	{
		private RssFeed _feed;

		public RssFeed Feed
		{
			get
			{
				return _feed;
			}
			set
			{
				_feed = value;
				Title.Text = _feed.Title;
			}
		}

		private void LinkOnClick(object sender, RoutedEventArgs routedEventArgs)
		{
			((Frame) Window.Current.Content).Navigate(typeof(MainPage), _feed);
		}

		public FeedItem()
		{
			this.InitializeComponent();
		}
	}
}
