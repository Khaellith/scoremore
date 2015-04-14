using System;
using Android.Media;

namespace SpinnerTest
{
	public abstract class Vraag
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
		//		Image afbeelding;
		//		public Image Afbeelding {
		//			get {
		//				return afbeelding;
		//			}
		//			set {
		//				afbeelding = value;
		//			}
		//		}

		string uitleg;
		public string Uitleg {
			get {
				return uitleg;
			}
			set {
				uitleg = value;
			}
		}

		public abstract bool Vergelijk (string value);
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

		//		public MultipleChoiceVraag(string vraagTekst,Image afbeelding, string uitleg, string[] antwoorden) {
		//			this.Vraagtekst = vraagTekst;
		//			this.Afbeelding = afbeelding;
		//			this.Uitleg = uitleg;
		//			this.Antwoorden = antwoorden;
		//		}

		public MultipleChoiceVraag(string vraagTekst, string uitleg, string[] antwoorden) {
			this.Vraagtekst = vraagTekst;
			this.Uitleg = uitleg;
			this.Antwoorden = antwoorden;
		}

		public override bool Vergelijk(string value) {
			return (Antwoorden [0] == value);
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

		//		public TrueFalseVraag(string vraagTekst,Image afbeelding, string uitleg, bool antwoord) {
		//			this.Vraagtekst = vraagTekst;
		//			this.Afbeelding = afbeelding;
		//			this.Uitleg = uitleg;
		//			this.Antwoord = antwoord;
		//		}

		public TrueFalseVraag(string vraagTekst, string uitleg, bool antwoord) {
			this.Vraagtekst = vraagTekst;
			this.Uitleg = uitleg;
			this.Antwoord = antwoord;
		}

		public override bool Vergelijk(string value) {
			return (Antwoord == (value.ToLower() == "true"));
		}
	}
}

