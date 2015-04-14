using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SpinnerTest
{
	[Activity (Label = "scoremore", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button ButtonTentamenMaken = FindViewById<Button> (Resource.Id.myButton);

			Button downloadButton = FindViewById<Button> (Resource.Id.button2);
			downloadButton.Click += delegate {
				StartActivity(typeof (VragenDownloaden));
			};

			Button resultaatButton = FindViewById<Button> (Resource.Id.button3);
			resultaatButton.Click += delegate {
				StartActivity(typeof(ResultatenOpvragen));

			};

			ButtonTentamenMaken.Click += delegate {
				StartActivity (typeof(SpinnerActivity));
			};
		}
	}			
}




