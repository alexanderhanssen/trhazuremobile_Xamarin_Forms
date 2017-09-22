using System;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile.Push;
using Xamarin.Forms;

namespace trhazuremobile
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new TodoList();
		}

		protected override void OnStart ()
		{
            // Handle when your app starts
		    MobileCenter.Start("c8972ad8-a269-4349-81c2-35695fe0882e",
		        typeof(Analytics), typeof(Crashes), typeof(Push));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

