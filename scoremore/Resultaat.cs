using System;
using System.Collections.Generic;

namespace scoremore
{
	public class Resultaat
	{
		public String Onderwerp;
		public String Subonderwerp;
		public DateTime datum;
		public List<KeyValuePair<Vraag, String>> antwoorden;
		double cijfer;
		public double Cijfer {
			get {
				return Math.Round(cijfer,2);
			}
		}

		public Resultaat (String onderwerp, String subonderwerp, List<KeyValuePair<Vraag, String>> antwoorden)
		{
			this.Onderwerp = onderwerp;
			this.Subonderwerp = subonderwerp;
			this.datum = DateTime.Now;
			this.antwoorden = antwoorden;
			int goed = 0;
			foreach (KeyValuePair<Vraag, String> antwoord in antwoorden) {
				if (antwoord.Key.Vergelijk (antwoord.Value))
					goed++;
			}
			cijfer = goed / antwoorden.Count;
		}
	}
}

