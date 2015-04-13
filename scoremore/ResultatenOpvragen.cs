
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

namespace scoremore
{
	[Activity (Label = "ResultatenOpvragen")]			
	public class ResultatenOpvragen : ListActivity
	{
		List<String> resultatenLijst;
		string[] resultatenArray;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.ResultatenOpvragen);
			resultatenLijst = new List<String> ();
			foreach (Resultaat resultaat in Singleton.CurrentUser.Resultaten) {
				resultatenLijst.Add(resultaat.Onderwerp + ": " + resultaat.Subonderwerp + " - "+ resultaat.datum + " - " + resultaat.Cijfer);
			}
			ListView resultaatListView = FindViewById<ListView> (Resource.Id.listView1);
			resultatenArray = resultatenLijst.ToArray ();
			ListAdapter = new ArrayAdapter<String>(this, Resource.Layout.ResultatenOpvragen, resultatenArray);
		}

		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
			base.OnListItemClick (l, v, position, id);
			BekijkResultaat (Singleton.CurrentUser.Resultaten.ElementAt(position));
		}

		void BekijkResultaat(Resultaat r) {
			SetContentView (Resource.Layout.ResultaatBekijken);
			//TODO: code uit Nieki's "vraag beantwoorden" use-case gebruiken om vraag + antwoord te weergeven
		}
	}

	[Activity (Label = "ResultaatBekijken")]			
	public class ResultaatBekijken : Activity
	{
		//TODO: code uit Nieki's "vraag beantwoorden" use-case gebruiken om vraag + antwoord te weergeven
	}
}

