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

		protected override async void OnStart ()
		{
            // Handle when your app starts
		    MobileCenter.Start(
                "uwp=df13eb47-6f23-4e8f-841f-8c9838cef8ff;" +
                "android=c8972ad8-a269-4349-81c2-35695fe0882e;",
		        typeof(Analytics), typeof(Crashes), typeof(Push));

            Push.PushNotificationReceived += (sender, e) => {

                // Add the notification message and title to the message
                var summary = $"Push notification received:" +
                                    $"\n\tNotification title: {e.Title}" +
                                    $"\n\tMessage: {e.Message}";

                // If there is custom data associated with the notification,
                // print the entries
                if (e.CustomData != null)
                {
                    summary += "\n\tCustom data:\n";
                    foreach (var key in e.CustomData.Keys)
                    {
                        summary += $"\t\t{key} : {e.CustomData[key]}\n";
                    }
                }

                // Send the notification summary to debug output
                System.Diagnostics.Debug.WriteLine(summary);
            };
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

