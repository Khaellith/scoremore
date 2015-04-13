
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
using Android;
using scoremore;

namespace scoremore
{
	[Activity (Label = "LaadTentamenActivity")]			
	public class LaadTentamenActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			//base.OnCreate (bundle);
	
			//Spinner spinnerOnderwerp = new Spinner ();

			List<String> SpinnerInhoud = new List<String> ();

			foreach (KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>> onderwerpKVP in Singleton.LocalDatabase) {
				foreach (KeyValuePair<String, List<Vraag>> subonderwerpKVP in onderwerpKVP.Value) {
					SpinnerInhoud.Add (onderwerpKVP.Key + ": " + subonderwerpKVP.Key);
				}}
			


		}
			
	}
}

