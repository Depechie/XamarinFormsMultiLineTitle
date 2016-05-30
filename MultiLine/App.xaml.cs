using Xamarin.Forms;
using MultiLine.Views;

namespace MultiLine
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent ();
			NavigationPage mainPage = new NavigationPage(new MainPage ());	
			MainPage = mainPage;
		}
	}
}