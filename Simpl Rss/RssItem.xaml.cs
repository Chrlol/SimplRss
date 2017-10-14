using System;
using Windows.System;
using Windows.UI.Xaml.Controls;
using SmplRSS.Models;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SmplRSS
{
	public sealed partial class RssItem : UserControl
	{
		private RssFeeditem _item;
		private string _itemUri;
		public RssFeeditem Item
		{
			set
			{
				_item = value;
				Text.Text = _item.Summary;
				Title.Text = _item.Title;
				_itemUri = _item.Url;
				Title.DoubleTapped += FollowLink;
				var uri = _item.Url;
				if (uri != null)
					_itemUri= uri;
				DoubleTapped += FollowLink;
				Link.Click += FollowLink;
			}
			get { return _item; }
		}

		private async void FollowLink(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			await Launcher.LaunchUriAsync(new Uri(_itemUri));
		}

		public RssItem()
		{
			this.InitializeComponent();
		}
	}
}
