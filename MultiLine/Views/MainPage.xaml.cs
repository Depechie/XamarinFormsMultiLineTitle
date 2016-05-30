using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MultiLine.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		private void OnButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync (new DetailPage ());
		}

		private void OnButton2Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync (new OtherDetailPage ());
		}
	}
}

