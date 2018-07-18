using System;

using Android.App;
using Android.Views;
using Android.OS;
using Java.Interop;
using SampleApp.Helpers;
using Android.Content.PM;
using Android;
using Android.Support.V4.App;
using Android.Support.V4.Content;

namespace Samples.Droid
{
	[Activity(Label = "Judopay", Icon = "@drawable/ic_launcher", Theme = "@style/JudoTheme", ScreenOrientation = ScreenOrientation.Locked, MainLauncher = true)]
	public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);
			Xamarin.Forms.Forms.Init(this, bundle);

			Window.SetSoftInputMode(SoftInput.AdjustResize);
	
			LoadApplication(new App());
		}

        protected override void OnStart()
        {
            base.OnStart();

            if (ContextCompat.CheckSelfPermission(this, "Location") != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation, Manifest.Permission.AccessWifiState }, 0);
                //ActivityCompat.re
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Permission Granted!!!");
            }
        }

        [Export("SetSetting")]
		public string SetSetting(string setting)
		{
			switch (setting)
			{
				case "Maestro":
					Settings.MaestroAllowed = true;
					break;
				case "Amex":
					Settings.AmexAllowed = true;
					break;
				case "AVS":
					Settings.AvsEnabled = true;
					break;
				default:
					throw new ArgumentException(setting + " is not a recognised setting");
			}
			return setting;
		}
	}
}
