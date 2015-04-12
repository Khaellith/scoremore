using System;
using System.Collections.Generic;
using System.Linq;

namespace scoremore
{
	public class Tentamen
	{
		List<Vraag> vragen;
		String onderwerp;
		String subonderwerp;

		public Tentamen (string onderwerp, string subonderwerp, int aantalVragen)
		{
			this.onderwerp = onderwerp;
			this.subonderwerp = subonderwerp;
			List<Vraag> databaseVragen;
			foreach (KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>> onderwerpKVP in Singleton.LocalDatabase) {
				if (onderwerpKVP.Key == onderwerp) {
					foreach (KeyValuePair<String, List<Vraag>> subonderwerpKVP in onderwerpKVP) {
						if (subonderwerpKVP.Key == subonderwerp) {
							databaseVragen = subonderwerpKVP.Value;
						}
					}
				}
			}
			if (databaseVragen != null && databaseVragen.Count >= aantalVragen) {
				Random rng = new Random ();
				vragen = (List<Vraag>)databaseVragen.OrderBy (x => rng.Next ()).Take (aantalVragen);
			} else {
				Console.WriteLine("Error: niet genoeg vragen om een tentamen van " + aantalVragen + " vragen voor dit onderwerp te maken.");
			}
		}
	}
}

