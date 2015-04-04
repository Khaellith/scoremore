using System;
using Android.Media;

namespace scoremore
{
	abstract class Vraag
	{
		string vraagtekst;
		public string Vraagtekst {
			get {
				return vraagtekst;
			}
			set {
				vraagtekst = value;
			}
		}
		Image afbeelding;
		public Image Afbeelding {
			get {
				return afbeelding;
			}
			set {
				afbeelding = value;
			}
		}

		string uitleg;
		public string Uitleg {
			get {
				return uitleg;
			}
			set {
				uitleg = value;
			}
		}
	}

	class MultipleChoiceVraag : Vraag
	{
		string[] antwoorden;
		public string[] Antwoorden {
			get {
				return antwoorden;
			}
			set {
				antwoorden = value;
			}
		}

		MultipleChoiceVraag(string vraagTekst,Image afbeelding, string uitleg, string[] antwoorden) {
			this.Vraagtekst = vraagTekst;
			this.Afbeelding = afbeelding;
			this.Uitleg = uitleg;
			this.Antwoorden = antwoorden;
		}

		MultipleChoiceVraag(string vraagTekst, string uitleg, string[] antwoorden) {
			this.Vraagtekst = vraagTekst;
			this.Uitleg = uitleg;
			this.Antwoorden = antwoorden;
		}
	}

	class TrueFalseVraag : Vraag
	{
		bool antwoord;
		public bool Antwoord {
			get {
				return antwoord;
			}
			set {
				antwoord = value;
			}
		}

		TrueFalseVraag(string vraagTekst,Image afbeelding, string uitleg, bool antwoord) {
			this.Vraagtekst = vraagTekst;
			this.Afbeelding = afbeelding;
			this.Uitleg = uitleg;
			this.Antwoord = antwoord;
		}

		TrueFalseVraag(string vraagTekst, string uitleg, bool antwoord) {
			this.Vraagtekst = vraagTekst;
			this.Uitleg = uitleg;
			this.Antwoord = antwoord;
		}
	}
}

