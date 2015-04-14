using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SpinnerTest
{
	[Activity (Label = "ScoreMore", MainLauncher = true, Icon = "@drawable/Icon")]
	public class Inloggen : Activity
	{
		EditText LoginNaam, Password;
		string InlogFout, veld1, veld2;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Inloggen);



			// Get our button from the layout resource,
			// and attach an event to it


			Button Inloggen = FindViewById<Button> (Resource.Id.Inloggen);
			Inloggen.Click += delegate {
				Login ();
			};

			LoginNaam = FindViewById<EditText> (Resource.Id.InlogNaam);
			Password = FindViewById<EditText> (Resource.Id.Wachtwoord);
			InlogFout = "Login incorrect";

			veld1 = LoginNaam.Text;
			veld2 = Password.Text;
			LoginNaam.TextChanged += (sender, e) => {      
				veld1 += e.Text.ToString ();
			};
			Password.TextChanged += (sender, e) => {
				veld2 += e.Text.ToString ();
			};




		}
		public void Login () {

			veld1 = LoginNaam.Text;
			veld2 = Password.Text;

			if (veld1 == "test" && veld2 == "test")
				StartActivity (typeof(MainActivity));

			else
				Toast.MakeText (this, InlogFout, ToastLength.Short).Show();
		}
	}
}



