
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
	[Activity (Label = "MaakTentamenGeschiedenis", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]			
	public class MaakTentamenGeschiedenis : Activity, GestureDetector.IOnGestureListener
	{
		private GestureDetector gestureDetector;
		private TextView vraag;
		private RadioButton A;
		private RadioButton B;
		private RadioButton C;
		private RadioButton D; 
		private RadioGroup rg;
		int i;
		List<String> vragenlijst;
		private List<String> antwoordA;
		private List<String> antwoordB;
		private List<String> antwoordC;
		private List<String> antwoordD;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.VraagBeantwoorden);

			i = 0;

			vragenlijst = new List<string>(){"Wie was de aanstichter van de Tweede Wereldoorlog?", "Wat wilde Hitler met de oorlog bereiken?", "Een bekend Nederlands concentratiekamp was...","Uit welk(e) land(en) kwam(en) de 'geallieerden'?","Waar staat het begrip 'D-day'"};
			antwoordA = new List<string> (){ "Josef Mengele","Opsluiting van alle joden en zigeuners in gevangenissen en concentratiekampen.","Westerbork","Duitsland en Oostenrijk","Division-day"};
			antwoordB = new List<string> (){ "Adolf Eichmann","Eén groot Duits Rijk in Europa met een zuiver Duitse bevolking.","Mechelen","Japan","Demolishion-day"};
			antwoordC = new List<string> (){ "Adolf Hitler","Uitroeiing van alle burgers.","Auschwitz","Italië, Oostenrijk en Spanje","Direction-day"};
			antwoordD = new List<string> (){ "Joseph Goebbels","Stimulering van de werkgelegenheid: voor het maken van wapens was veel personeel nodig.","Sobibór","Frankrijk, Engeland, Rusland, de Verenigde Staten en Canada","Decision-day"};

			vraag = FindViewById<TextView> (Resource.Id.textview1);
			vraag.Text = vragenlijst [i];

			A = FindViewById<RadioButton> (Resource.Id.radioButton1);
			A.Text = antwoordA[i];

			B = FindViewById<RadioButton> (Resource.Id.radioButton2);
			B.Text = antwoordB[i];

			C = FindViewById<RadioButton> (Resource.Id.radioButton3);
			C.Text = antwoordC[i];

			D = FindViewById<RadioButton> (Resource.Id.radioButton4);
			D.Text = antwoordD[i];
			rg = FindViewById<RadioGroup> (Resource.Id.radioGroup1);

			gestureDetector = new GestureDetector(this);

			// Create your application here
		}



		public override bool OnTouchEvent(MotionEvent e)
		{
			gestureDetector.OnTouchEvent(e);
			return false;
		}

		public bool OnDown(MotionEvent e)
		{
			return false;
		}

		public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			if (velocityX < 0 && i >= 0 && i <= 4 ){
				if( i < 4 ){
					i = i + 1;
					vraag.Text = vragenlijst [i];
					A.Text = antwoordA[i];
					B.Text = antwoordB[i];
					C.Text = antwoordC[i];
					D.Text = antwoordD[i];
					A.Checked = true;
				}
			}

			if (velocityX > 0 && i >= 0 && i <= 4) {
				if (i > 0) {
					i = i - 1;
					vraag.Text = vragenlijst[i];
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
