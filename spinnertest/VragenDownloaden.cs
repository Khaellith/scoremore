
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
	[Activity (Label = "Vragen Downloaden", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]			
	public class VragenDownloaden : ListActivity
	{
		VragenDownloader dl;
		List<String> onderwerpLijst;
		string[] onderwerpArray;
//		Button dlButton;
		List<String> selectie;
//		ListView onderwerpListView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
//			SetContentView (Resource.Layout.VragenDownloaden);
//			onderwerpListView = FindViewById<ListView>(Resource.Id.listView1);
//			dlButton = FindViewById<Button> (Resource.Id.button1);
//			dlButton.Click += delegate {
//				Download();
//			};
			dl  = new VragenDownloader();
			dl.CheckOnlineVragen ();
			onderwerpLijst = new List<string> ();
			foreach (KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>> onderwerpKVP in Singleton.OnlineDatabase) {
				foreach (KeyValuePair<String, List<Vraag>> subonderwerpKVP in onderwerpKVP.Value) {
					onderwerpLijst.Add (onderwerpKVP.Key + ": " + subonderwerpKVP.Key);
				}
			}
			onderwerpLijst.Sort();
			onderwerpArray = onderwerpLijst.ToArray ();
			ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItemActivated1, onderwerpArray);
			selectie = new List<String> ();
		}

		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
//			base.OnListItemClick (l, v, position, id);
//			if (!selectie.Contains(onderwerpArray[position])) {
//				selectie.Add (onderwerpArray [position]);
//			} else {
//				selectie.Remove (onderwerpArray [position]);
			//			}
			string[] sep = { ": " };
			string[] splitString = onderwerpArray[position].Split (sep, StringSplitOptions.None);
			dl.DownloadVragen (splitString [0], splitString [1]);

			Toast toast = Toast.MakeText(this, "Vragen voor " + onderwerpArray[position] + " gedownload!", ToastLength.Short);
			toast.Show();
		}

//		void Download() {
//			foreach (String geselecteerdOnderwerp in selectie) {
//				string[] sep = { ": " };
//				string[] splitString = geselecteerdOnderwerp.Split (sep, StringSplitOptions.None);
//				dl.DownloadVragen (splitString [0], splitString [1]);
//			}
//		}
	}
}

