
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
	[Activity (Label = "MaakTentamen")]			
	public class MaakTentamen : Activity, GestureDetector.IOnGestureListener
	{
		private GestureDetector _gestureDetector;
		private TextView _textView;
		private TextView vraag;
		private RadioButton A;
		private RadioButton B;
		private RadioButton C;
		private RadioButton D; 
		private RadioGroup rg;
		int i;
		List<Vraag> vragenlijst;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			i = 0;
			SetContentView (Resource.Layout.VraagBeantwoorden);

			vragenlijst = new List<Vraag>();
			VragenDownloader dl = new VragenDownloader ();
			dl.CheckOnlineVragen ();
			dl.DownloadVragen ("wiskunde","wiskunde");
			foreach (KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>> onderwerpKVP in Singleton.LocalDatabase) {
				foreach (KeyValuePair<String, List<Vraag>> subonderwerpKVP in onderwerpKVP.Value) {
					vragenlijst = subonderwerpKVP.Value;
				}
			}


			_textView = FindViewById<TextView>(Resource.Id.velocity_text_view);
			_textView.Text = "Fling Velocity: ";

			vraag = FindViewById<TextView> (Resource.Id.textview1);
			vraag.Text = vragenlijst.ElementAt (i).Vraagtekst;

			A = FindViewById<RadioButton> (Resource.Id.radioButton1);
			A.Text = "A: 2";

			B = FindViewById<RadioButton> (Resource.Id.radioButton2);
			B.Text = "B: 1";

			C = FindViewById<RadioButton> (Resource.Id.radioButton3);
			C.Text = "C: 3";

			D = FindViewById<RadioButton> (Resource.Id.radioButton4);
			D.Text = "D: 4";
			rg = FindViewById<RadioGroup> (Resource.Id.radioGroup1);

			_gestureDetector = new GestureDetector(this);

			// Create your application here
		}



		public override bool OnTouchEvent(MotionEvent e)
		{
			_gestureDetector.OnTouchEvent(e);
			return false;
		}

		public bool OnDown(MotionEvent e)
		{
			return false;
		}

		public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			_textView.Text = String.Format("Fling velocity: {0} x {1}", velocityX, velocityY);
			if (velocityX < 0 ){
				{
					i = i + 1;
					vraag.Text = vragenlijst.ElementAt (i).Vraagtekst;
					A.Text = "A: 4";
					B.Text = "B: 2";
					C.Text = "C: 1";
					D.Text = "D: 3";
					A.Checked = true;
				}
			}

			if (velocityX > 0 && i >= 0 && i <= 20) {
				if (i > 0) {
					i = i - 1;
					vraag.Text = vragenlijst.ElementAt (i).Vraagtekst;
					A.Checked = true;
				}
			}



			return true;
		}

		public void OnLongPress(MotionEvent e) {}

		public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
		{
			return false;
		}

		public void OnShowPress(MotionEvent e) {}

		public bool OnSingleTapUp(MotionEvent e)
		{
			return false;
		}


	}
}
