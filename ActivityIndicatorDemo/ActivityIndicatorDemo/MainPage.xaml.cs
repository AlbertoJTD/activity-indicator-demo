using Acr.UserDialogs.Extended;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ActivityIndicatorDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			//UserDialogs.Instance.ShowLoading("Scanning");
			//await Task.Delay(5000);
			//UserDialogs.Instance.HideLoading();
			//await DisplayAlert("Task finished", "The task is finished", "OK");

			bool cancel = false;

			using (var dialog = UserDialogs.Instance.Progress("Loading", () => cancel = true, "Cancel"))
			{
				for (int i = 1; i <= 10; i++)
				{
					await Task.Delay(1000);
					if (!cancel)
					{
						dialog.PercentComplete = i * 10;
					}
				}
			};
		}
	}
}
