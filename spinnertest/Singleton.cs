//Thread safe singleton van https://msdn.microsoft.com/en-us/library/ff650316.aspx, gebruikt voor local & online vragendatabase
using System;
using System.Collections.Generic;

namespace SpinnerTest
{
	public sealed class Singleton
	{
		private static volatile Singleton instance;
		private static object syncRoot = new Object();

		private static List<KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>>> localDatabase;

		public static List<KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>>> LocalDatabase {
			get {
				return localDatabase;
			}
			set {
				localDatabase = value;
			}
		}

		private static List<KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>>> onlineDatabase;

		public static List<KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>>> OnlineDatabase {
			get {
				return onlineDatabase;
			}
			set {
				onlineDatabase = value;
			}
		}

		private static User currentUser;

		public static User CurrentUser {
			get {
				return currentUser;
			}
			set {
				currentUser = value;
			}
		}

		private Singleton() {}

		public static Singleton Instance
		{
			get 
			{
				if (instance == null) 
				{
					lock (syncRoot) 
					{
						if (instance == null) 
							instance = new Singleton();
					}
				}

				return instance;
			}
		}
	}
}

