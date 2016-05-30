using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Widget;
using Android.App;
using Android.Views;
using MultiLine.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(ContentPage), typeof(CustomContentPageRenderer))]
namespace MultiLine.Droid.CustomRenderers
{
	public class CustomContentPageRenderer : PageRenderer
	{
		public CustomContentPageRenderer ()
		{
		}

		private void Element_Appearing(object sender, EventArgs e)
		{
			var page = (ContentPage)Element;
			ActionBar actionBar = ((Activity)Context).ActionBar;

			if (!string.IsNullOrEmpty (page.Title) && actionBar.CustomView != null)
				((TextView)actionBar.CustomView).Text = page.Title;
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged (e);

			if (Element != null)
			{
				Element.Appearing += Element_Appearing;

				var page = (ContentPage)Element;

				if (!string.IsNullOrEmpty (page.Title))
				{
					ActionBar actionBar = ((Activity)Context).ActionBar;

					if (actionBar.CustomView == null)
					{
						TextView title = new TextView (this.Context);
						title.SetMaxLines (2);
						title.Gravity = GravityFlags.CenterVertical;

						actionBar.SetDisplayShowCustomEnabled (true);
						actionBar.SetCustomView (title, new ActionBar.LayoutParams (LayoutParams.MatchParent, LayoutParams.MatchParent));
					}

					((TextView)actionBar.CustomView).Text = page.Title;
				}
			}
		}
	}
}