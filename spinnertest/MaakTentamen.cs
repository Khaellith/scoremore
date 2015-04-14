
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
		private List<String> antwoordA;
		private List<String> antwoordB;
		private List<String> antwoordC;
		private List<String> antwoordD;

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
			antwoordA = new List<string> (){ "2","4","7","3","-1","16","11","1","-2","68","pi","36","6","12","-7","16","24","-3","0","4","210"};
			antwoordB = new List<string> (){ "1","2","6","2","1","2","2","0", "2","48","i","1","8","9","0","2","21","3","23","-1","1024"};
			antwoordC = new List<string> (){ "3","1","5","4","2","4","-1","10","0","40","1","0","4","20","9","-2","10","2","3","0","-11"};
			antwoordD = new List<string> (){ "4","3","4","1","0","-2","1","-1","1","36","e","-1","2","16","1","-4","-14","1","-1","-3","16"};


			_textView = FindViewById<TextView>(Resource.Id.velocity_text_view);
			_textView.Text = "Fling Velocity: ";

			vraag = FindViewById<TextView> (Resource.Id.textview1);
			vraag.Text = vragenlijst.ElementAt (i).Vraagtekst;

			A = FindViewById<RadioButton> (Resource.Id.radioButton1);
			A.Text = antwoordA[i];

			B = FindViewById<RadioButton> (Resource.Id.radioButton2);
			B.Text = antwoordB[i];

			C = FindViewById<RadioButton> (Resource.Id.radioButton3);
			C.Text = antwoordC[i];

			D = FindViewById<RadioButton> (Resource.Id.radioButton4);
			D.Text = antwoordD[i];
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
			if (velocityX < 0 && i >= 0 && i <= 20 ){
				if( i < 20 ){
					i = i + 1;
					vraag.Text = vragenlijst.ElementAt (i).Vraagtekst;
					A.Text = antwoordA[i];
					B.Text = antwoordB[i];
					C.Text = antwoordC[i];
					D.Text = antwoordD[i];
					A.Checked = true;
				}
			}

			if (velocityX > 0 && i >= 0 && i <= 20) {
				if (i > 0) {
					i = i - 1;
					vraag.Text = vragenlijst.ElementAt (i).Vraagtekst;
					A.Text = antwoordA[i];
					B.Text = antwoordB[i];
					C.Text = antwoordC[i];
					D.Text = antwoordD[i];
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
