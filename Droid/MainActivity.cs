using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Gcm.Client;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace trhazuremobile.Droid
{
	[Activity (Label = "trhazuremobile.Droid",
		Icon = "@drawable/icon",
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
		Theme = "@android:style/Theme.Holo.Light")]
	public class MainActivity : FormsApplicationActivity
	{

	    // Create a new instance field for this activity.
	    static MainActivity instance = null;

	    // Return the current activity instance.
	    public static MainActivity CurrentActivity
	    {
	        get
	        {
	            return instance;
	        }
	    }

        protected override void OnCreate (Bundle bundle)
		{
		    // Set the current instance of MainActivity.
		    instance = this;
            base.OnCreate (bundle);

			// Initialize Azure Mobile Apps
			CurrentPlatform.Init();

			// Initialize Xamarin Forms
			Forms.Init (this, bundle);

			// Load the main application
			LoadApplication (new App ());
		    try
		    {
		        // Check to ensure everything's set up right
		        GcmClient.CheckDevice(this);
		        GcmClient.CheckManifest(this);

		        // Register for push notifications
		        System.Diagnostics.Debug.WriteLine("Registering...");
		        GcmClient.Register(this, PushHandlerBroadcastReceiver.SENDER_IDS);
		    }
		    catch (Java.Net.MalformedURLException)
		    {
		        CreateAndShowDialog("There was an error creating the client. Verify the URL.", "Error");
		    }
		    catch (Exception e)
		    {
		        CreateAndShowDialog(e.Message, "Error");
		    }
        }

	    private void CreateAndShowDialog(String message, String title)
	    {
	        AlertDialog.Builder builder = new AlertDialog.Builder(this);

	        builder.SetMessage(message);
	        builder.SetTitle(title);
	        builder.Create().Show();
	    }
    }
}

