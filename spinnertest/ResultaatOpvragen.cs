
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
	[Activity (Label = "Resultaten Opvragen", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class ResultatenOpvragen : ListActivity
	{
		List<String> resultatenLijst;
		string[] resultatenArray;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
//			SetContentView (Resource.Layout.ResultatenOpvragen);
//			resultatenLijst = new List<String> ();
//			foreach (Resultaat resultaat in Singleton.CurrentUser.Resultaten) {
//				resultatenLijst.Add(resultaat.Onderwerp + ": " + resultaat.Subonderwerp + " - "+ resultaat.datum + " - " + resultaat.Cijfer);
//			}
			resultatenLijst = new List<String>();
			resultatenLijst.Add("wiskunde: wiskunde - 06/04/2015 - 6,2");
			resultatenLijst.Add("wiskunde: wiskunde - 09/04/2015 - 8,3");
			resultatenLijst.Add("wiskunde: wiskunde - 13/04/2015 - 9,5");
			resultatenLijst.Add("geschiedenis: middeleeuwen - 21/04/2015 - 4,5");
			resultatenLijst.Add("geschiedenis: middeleeuwen - 22/04/2015 - 5,9");
//			ListView resultaatListView = FindViewById<ListView> (Resource.Id.listView1);
			resultatenArray = resultatenLijst.ToArray ();
			ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, resultatenArray);
		}

		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
//			base.OnListItemClick (l, v, position, id);
//			BekijkResultaat (Singleton.CurrentUser.Resultaten.ElementAt(position));
//			SetContentView (Resource.Layout.ResultaatBekijken);
			StartActivity (typeof(ResultaatBekijken));
		}

		void BekijkResultaat(Resultaat r) {
			StartActivity (typeof(ResultaatBekijken));
			//TODO: code uit Nieki's "vraag beantwoorden" use-case gebruiken om vraag + antwoord te weergeven
		}
	}

	[Activity (Label = "ResultaatBekijken", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]			
	public class ResultaatBekijken : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			//TODO: code uit Nieki's "vraag beantwoorden" use-case gebruiken om vraag + antwoord te weergeven
			SetContentView (Resource.Layout.ResultaatBekijken);
		}
	}
}

