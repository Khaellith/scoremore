using NUnit.Framework;
using System;
using System.Collections.Generic;

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
			Assert.IsTrue (wiskundeGevonden);
		}
	}
}

