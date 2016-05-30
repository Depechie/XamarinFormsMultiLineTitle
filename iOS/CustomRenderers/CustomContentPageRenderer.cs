using System;
using Xamarin.Forms;
using MultiLine.iOS.CustomRenderers;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(ContentPage), typeof(CustomContentPageRenderer))]
namespace MultiLine.iOS.CustomRenderers
{
	public class CustomContentPageRenderer : PageRenderer
	{
		public CustomContentPageRenderer ()
		{
		}

		public override void WillMoveToParentViewController(UIViewController parent)
		{
			base.WillMoveToParentViewController(parent);

			var page = (ContentPage)Element;

			if (!string.IsNullOrEmpty (page.Title))
			{
				UILabel titleLabel = new UILabel ();
				titleLabel.LineBreakMode = UILineBreakMode.TailTruncation;
				titleLabel.Lines = 2;
				titleLabel.Text = page.Title;

				//Be sure to set the Frame to 'something' other than the default 0,0,0,0 otherwise you won't see anything!
				titleLabel.Frame = new CoreGraphics.CGRect (0, 0, 1, 1);
				titleLabel.SizeToFit ();

				parent.NavigationItem.TitleView = titleLabel;
			}
		}
	}
}