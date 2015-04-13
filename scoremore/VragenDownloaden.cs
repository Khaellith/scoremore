
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
	public class VragenDownloaden : Activity
	{
		VragenDownloader dl;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			dl  = new VragenDownloader();
			// Create your application here
		}
	}
}

