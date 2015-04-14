using System;
using System.Collections.Generic;

namespace SpinnerTest
{
	public class User
	{
		String naam;
		public String Naam {
			get {
				return naam;
			}
			set {
				naam = value;
			}
		}

		String email;
		public String Email {
			get {
				return email;
			}
			set {
				email = value;
			}
		}

		List<Resultaat> resultaten;
		public List<Resultaat> Resultaten {
			get {// = ResultaatOpvragen()
				return resultaten;
			}
			set {
				resultaten = value;
			}
		}

		public User (String naam, String email)
		{
			this.naam = naam;
			this.email = email;
			resultaten = new List<Resultaat> ();
		}

		public void GroepMaken(String groepsnaam) {

		}
	}

	class Groepslid : User
	{
		List<String> groepen;
		public List<String> Groepen {
			get {
				return groepen;
			}
			set {
				groepen = value;
			}
		}

		public Groepslid(String naam, String email, String groep) : base (naam, email)
		{
			groepen = new List<String>();//TODO: check of groepsnaam uniek is
			groepen.Add(groep);
		}
	}

	class Groepsleider : Groepslid
	{
		public Groepsleider(String naam, String email, String groep) : base (naam, email, groep) {}

		public void GroepslidVerwijderen(Groepslid lid, String groep) {
			if (this.Groepen.Contains(groep)) {//TODO: hoe weet je wie groepsleider van die groep is?
				lid.Groepen.Remove (groep);
			}
		}
	}
}

