using System;
using System.Collections.Generic;

namespace scoremore
{
	public class Resultaat
	{
		public List<KeyValuePair<Vraag, String>> antwoorden;
		double cijfer;
		public double Cijfer {
			get {
				return Math.Round(cijfer,2);
			}
		}

		public Resultaat (List<KeyValuePair<Vraag, String>> antwoorden)
		{
			this.antwoorden = antwoorden;
			int goed = 0;
			foreach (KeyValuePair<Vraag, String> antwoord in antwoorden) {
				if (antwoord.Key.Vergelijk (antwoord.Value))
					goed++;
				/*
				if (antwoord.Key.GetType == MultipleChoiceVraag) {
					if (antwoord.Key.Antwoorden[0] == antwoord.Value) {
						goed++;
					}
				} else {
					if (antwoord.Key.Antwoord == (antwoord.Value.ToLower == "true")) {
						goed++;
					}
				}
				*/
			}
			cijfer = goed / antwoorden.Count;
		}
	}
}

