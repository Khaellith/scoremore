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

			Button downloadButton = FindViewById<Button> (Resource.Id.button2);
			downloadButton.Click += delegate {
				SetContentView(Resource.Layout.VragenDownloaden);
			};

			Button resultaatButton = FindViewById<Button> (Resource.Id.button3);
			resultaatButton.Click += delegate {
				SetContentView(Resource.Layout.ResultatenOpvragen);
			};
		}

		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;

			if (e.Position == 1) {
				string onderwerp = "wiskunde";
				string subonderwerp = "wiskunde";

			}
		}
			
	}
}



