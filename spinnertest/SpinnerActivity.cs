
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SpinnerTest
{
	[Activity (Label = "SpinnerActivity")]			
	public class SpinnerActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.TentamenStarten);
			Spinner spinnerOnderwerp = FindViewById<Spinner> (Resource.Id.spinner);

			spinnerOnderwerp.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.onderwerp_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinnerOnderwerp.Adapter = adapter;


			// Create your application here
		}
		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			string toast = string.Format ("Het onderwerp is {0}", spinner.GetItemAtPosition (e.Position));
			Toast.MakeText (this, toast, ToastLength.Long).Show ();

			if (e.Position == 1) {
				Button startTentamen = FindViewById<Button> (Resource.Id.button1);
				startTentamen.Click += delegate {
					StartActivity (typeof(MaakTentamen));
				};
			}
		}
	}
}
