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
			List<KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>>> localDB = Singleton.LocalDatabase;
			VragenDownloader dl = new VragenDownloader ();
			bool wiskundeGevonden = false;
			dl.CheckLocalVragen ();
			foreach (var onderwerpKVP in localDB) {
				if (onderwerpKVP.Key == "wiskunde") {
					wiskundeGevonden = true;
				}
			}
			Assert.IsFalse (wiskundeGevonden);//nog geen vragen gedownload
		}

		[Test ()]
		public void TestCase02 ()
		{
			List<KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>>> onlineDB = Singleton.OnlineDatabase;
			VragenDownloader dl = new VragenDownloader ();
			bool wiskundeGevonden = false;
			dl.CheckOnlineVragen ();
			foreach (var onderwerpKVP in onlineDB) {
				if (onderwerpKVP.Key == "wiskunde") {
					wiskundeGevonden = true;
				}
			}
			Assert.IsTrue (wiskundeGevonden);//online db heeft wiskundevragen
		}

		[Test ()]
		public void TestCase03 ()
		{
			List<KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>>> localDB = Singleton.LocalDatabase;
			VragenDownloader dl = new VragenDownloader ();
			bool wiskundeGevonden = false;
			dl.DownloadVragen ("wiskunde", "wiskunde");
			dl.CheckLocalVragen ();
			foreach (var onderwerpKVP in localDB) {
				if (onderwerpKVP.Key == "wiskunde") {
					wiskundeGevonden = true;
				}
			}
			Assert.IsTrue (wiskundeGevonden);//na downloaden moeten er wel wiskunde vragen in local database staan
		}
	}
}

