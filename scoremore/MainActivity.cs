using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace scoremore
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
			
			ButtonTentamenMaken.Click += delegate {
				SetContentView (Resource.Layout.TentamenStarten);

				Spinner spinnerOnderwerp = FindViewById<Spinner> (Resource.Id.spinner);

				spinnerOnderwerp.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
				var adapter = ArrayAdapter.CreateFromResource (
					this, Resource.Array.onderwerp_array, Android.Resource.Layout.SimpleSpinnerItem);

				adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
				spinnerOnderwerp.Adapter = adapter;
			};				
		}

		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			string toast = string.Format ("Het gekozen onderwerp is {0}", spinner.GetItemAtPosition (e.Position));

			if (e.Position == 1) {
				string test = "Hallo";
				Toast.MakeText (this, test, ToastLength.Long).Show ();
				Spinner spinnerSubonderwerp = FindViewById<Spinner> (Resource.Id.spinner1);

				spinnerSubonderwerp.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
				var adapter1 = ArrayAdapter.CreateFromResource (
					               this, Resource.Array.subonderwerpWiskunde_array, Android.Resource.Layout.SimpleSpinnerItem);

				adapter1.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
				spinnerSubonderwerp.Adapter = adapter1;

				spinner_ItemSelected (spinnerSubonderwerp, AdapterView.ItemSelectedEventArgs e));
		

			}
		}
			
	}
}



