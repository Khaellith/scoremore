using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace scoremore
{
	[Activity (Label = "scoremore", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Spinner spinnerOnderwerp = FindViewById<Spinner> (Resource.Id.spinner1);

			spinnerOnderwerp.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinnerOnderwerp_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.onderwerp_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinnerOnderwerp.Adapter = adapter;

			// Get our button from the layout resource,
			// and attach an event to it
			Button ButtonTentamenMaken = FindViewById<Button> (Resource.Id.myButton);
			
			ButtonTentamenMaken.Click += delegate {
				SetContentView (Resource.Layout.TentamenStarten);
			};				
		}

		private void spinnerOnderwerp_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinnerOnderwerp = (Spinner)sender;

			string toast = string.Format ("Het onderwerp is {0}", spinnerOnderwerp.GetItemAtPosition (e.Position));

		}
	}
}


