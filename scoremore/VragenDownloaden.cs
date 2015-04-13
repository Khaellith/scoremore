
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
	[Activity (Label = "VragenDownloaden")]			
	public class VragenDownloaden : ListActivity
	{
		VragenDownloader dl;
		List<String> onderwerpLijst;
		string[] onderwerpArray;
		Button dlButton;
		List<String> selectie;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			dlButton = FindViewById<Button> (Resource.Id.button1);
			dlButton.Click += delegate {
				Download();
			};
			SetContentView (Resource.Layout.VragenDownloaden);
			dl  = new VragenDownloader();
			dl.CheckOnlineVragen ();
			onderwerpLijst = new List<string> ();
			foreach (KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>> onderwerpKVP in Singleton.LocalDatabase) {
				foreach (KeyValuePair<String, List<Vraag>> subonderwerpKVP in onderwerpKVP.Value) {
					onderwerpLijst.Add (onderwerpKVP.Key + ": " + subonderwerpKVP.Key);
				}
			}
			//ListView onderwerpListView = new ListView ();
			ListView onderwerpListView = FindViewById<ListView>(Resource.Id.listView1);
//			onderwerpListView.
			onderwerpLijst.Sort();
			onderwerpArray = onderwerpLijst.ToArray ();
//			ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, onderwerpArray);
			ListAdapter = new ArrayAdapter<String>(this, Resource.Layout.VragenDownloaden, onderwerpArray);
			selectie = new List<String> ();
		}

		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
			base.OnListItemClick (l, v, position, id);
			if (!selectie.Contains(onderwerpArray[position])) {
				selectie.Add (onderwerpArray [position]);
			} else {
				selectie.Remove (onderwerpArray [position]);
			}
		}

		void Download() {
			foreach (String geselecteerdOnderwerp in selectie) {
				string[] sep = { ": " };
				string[] splitString = geselecteerdOnderwerp.Split (sep, StringSplitOptions.None);
				dl.DownloadVragen (splitString [0], splitString [1]);
			}
		}
	}
}

