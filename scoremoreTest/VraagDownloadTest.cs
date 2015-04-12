using NUnit.Framework;
using System;
using System.Collections.Generic;
using scoremore;

namespace scoremoreTest
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase01 ()
		{
			VragenDownloader dl = new VragenDownloader ();
			bool wiskundeGevonden = false;
			dl.CheckLocalVragen ();
			foreach (var onderwerpKVP in Singleton.LocalDatabase) {
				if (onderwerpKVP.Key == "wiskunde") {
					wiskundeGevonden = true;
				}
			}
			Assert.IsFalse (wiskundeGevonden);//nog geen vragen gedownload
		}

		[Test ()]
		public void TestCase02 ()
		{
			VragenDownloader dl = new VragenDownloader ();
			bool wiskundeGevonden = false;
			dl.CheckOnlineVragen ();
			foreach (var onderwerpKVP in Singleton.OnlineDatabase) {
				if (onderwerpKVP.Key == "wiskunde") {
					wiskundeGevonden = true;
				}
			}
			Assert.IsTrue (wiskundeGevonden);//online db heeft wiskundevragen
		}

		[Test ()]
		public void TestCase03 ()
		{
			VragenDownloader dl = new VragenDownloader ();
			bool wiskundeGevonden = false;
			dl.DownloadVragen ("wiskunde", "wiskunde");
			dl.CheckLocalVragen ();
			foreach (var onderwerpKVP in Singleton.LocalDatabase) {
				if (onderwerpKVP.Key == "wiskunde") {
					wiskundeGevonden = true;
				}
			}
			Assert.IsTrue (wiskundeGevonden);//na downloaden moeten er wel wiskunde vragen in local database staan
		}
	}
}

