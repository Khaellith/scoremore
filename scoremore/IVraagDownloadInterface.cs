using System;
using Android.Content.Res;
using System.IO;
using System.Collections.Generic;

namespace scoremore
{
	public interface IVraagDownloadInterface
	{
		bool CheckLocalVragen();
		bool CheckOnlineVragen();
		void DownloadVragen(string onderwerp, string subonderwerp);
	}

	public class VragenDownloader : IVraagDownloadInterface
	{
		/// <summary>
		/// Leest .txt files om local of "online" vragendatabase op te bouwen.
		/// </summary>
		/// <returns><c>true</c>, als database succesvol wordt opgebouwd, <c>false</c> als het .txt bestand niet gelezen kan worden.</returns>
		/// <param name="type">Type database (local/online).</param>
		private bool CheckVragen(String type) {
			string pad;
			List<KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>>> database;
			if (type == "online") {
				pad = "ms-appx:///Assets/online/";//werkt niet, dus niks werkt
				database = Singleton.OnlineDatabase;
			} else {
				pad = "ms-appx:///Assets/local/";
				database = Singleton.LocalDatabase;
			}
			//AssetManager am = context.getAssets();
			//TODO: loop om door alle mappen binnen /assets/local te bladeren

			string onderwerp = "wiskunde";
			string subonderwerp = "wiskunde";
			try
			{
				using (StreamReader sr = new StreamReader(pad + onderwerp + "/" + subonderwerp + ".txt"))
				{
					List<Vraag> vragenlijst = new List<Vraag>();
					String lines = sr.ReadToEnd();
					string[] vraagSeparator = {"\n\n"};
					string[] vragen = lines.Split(vraagSeparator, StringSplitOptions.None);
					foreach (var vraag in vragen) {
						string soort = "";
						string tekst = "";
						string uitleg = "";
						string[] antwoorden = {};
						bool antwoord = false;
						string[] onderdeelSeparator = {"\n"};
						string[] vraagonderdelen = vraag.Split(onderdeelSeparator, StringSplitOptions.None);
						foreach (var onderdeel in vraagonderdelen) {//TODO: support voor afbeeldingen toevoegen
							if (onderdeel == "MultipleChoice" || onderdeel == "TrueFalse") {
								soort = onderdeel;
							} else if (onderdeel.StartsWith("VraagTekst= ")) {
								tekst = onderdeel.Substring(12);
							} else if (onderdeel.StartsWith("Uitleg= ")) {
								uitleg = onderdeel.Substring(8);
							} else if (onderdeel.StartsWith("Antwoorden= ")) {
								string[] antwoordSeparator = {";"};
								antwoorden = onderdeel.Substring(12).Split(antwoordSeparator, StringSplitOptions.None);
							} else if (onderdeel.StartsWith("Antwoord= ")) {
								antwoord = (onderdeel.Substring(10) == "True");
							}
						}
						if (soort == "MultipleChoice") {
							Vraag nieuweVraag = new MultipleChoiceVraag(tekst, uitleg, antwoorden);
							vragenlijst.Add(nieuweVraag);
						} else if (soort == "TrueFalse") {
							Vraag nieuweVraag = new TrueFalseVraag(tekst, uitleg, antwoord);
							vragenlijst.Add(nieuweVraag);
						}
					}
					KeyValuePair<String, List<Vraag>> dbEntry = new KeyValuePair<String, List<Vraag>>(subonderwerp, vragenlijst);
					bool onderwerpGevonden = false;
					bool subonderwerpGevonden = false;
					KeyValuePair<String, List<Vraag>> gevondenSubonderwerpKVP = dbEntry;
					foreach (var onderwerpKVP in database) {
						if (onderwerpKVP.Key == onderwerp) {
							onderwerpGevonden = true;
							foreach (var subonderwerpKVP in onderwerpKVP.Value) {
								if (subonderwerpKVP.Key == subonderwerp) {
									subonderwerpGevonden = true;
									gevondenSubonderwerpKVP = subonderwerpKVP;
								}
							}
							if (subonderwerpGevonden) {
								onderwerpKVP.Value.Remove(gevondenSubonderwerpKVP);
							} 
							onderwerpKVP.Value.Add(dbEntry);
						}
					}
					if (!onderwerpGevonden) {
						database.Add(new KeyValuePair<string, List<KeyValuePair<string, List<Vraag>>>>(onderwerp, new List<KeyValuePair<string, List<Vraag>>>{dbEntry}));
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(e.Message);
				return false;
			}
			return true;
		}

		/// <summary>
		/// Bouwt local vragendatabase op uit .txt files.
		/// </summary>
		/// <returns><c>true</c>, als database succesvol wordt opgebouwd, <c>false</c> als het .txt bestand niet gelezen kan worden.</returns>
//		public bool CheckLocalVragen() {
//			return CheckVragen("local");
//		}
		public bool CheckLocalVragen() {
			if (Singleton.LocalDatabase == null) {
				Singleton.LocalDatabase = new List<KeyValuePair<string, List<KeyValuePair<string, List<Vraag>>>>> ();
			}
			return (Singleton.LocalDatabase != null && Singleton.LocalDatabase.Count >= 1);
		}

		/// <summary>
		/// Bouwt "online" vragendatabase op uit .txt files.
		/// </summary>
		/// <returns><c>true</c>, als database succesvol wordt opgebouwd, <c>false</c> als het .txt bestand niet gelezen kan worden.</returns>
//		public bool CheckOnlineVragen() {
//			return CheckVragen("online");
//		}
		public bool CheckOnlineVragen() {
			string onderwerp = "wiskunde";
			string subonderwerp = "wiskunde";
			List<KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>>> db = new List<KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>>> ();
			List<Vraag> vragen = new List<Vraag> ();
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 1 + 1 ?", "", new string[]{"2","1","3","4"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 1 + 2 ?", "", new string[]{"3","1","2","4"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 6 - 1 ?", "", new string[]{"5","6","7","4"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 1 * 1 ?", "", new string[]{"1","2","3","4"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 1 - 1 ?", "", new string[]{"0","1","2","-1"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is de wortel van 4 ?", "", new string[]{"2","4","-2","16"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 1^1 ?", "", new string[]{"1","2","11","-1"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 1^0 ?", "Iets tot de macht 0 is altijd 1.", new string[]{"1","0","10","-1"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 2^0 ?", "Iets tot de macht 0 is altijd 1.", new string[]{"1","0","2","-2"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 6 * 8 ?", "", new string[]{"48","68","40","36"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is de wortel van -1 ?", "", new string[]{"i","pi","e","1"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 0 ?", "", new string[]{"0","1","36","-1"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 2 + 4 ?", "", new string[]{"6","4","2","8"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 4 * 5 ?", "", new string[]{"20","9","16","12"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 1 - 8 ?", "", new string[]{"-7","9","0","1"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 12 - 14 ?", "", new string[]{"-2","16","2","-4"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 7 * 3 ?", "", new string[]{"21","24","10","-14"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel antwoorden heeft x^2 = 9 ?", "", new string[]{"2","3","-3","1"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel letters heeft de stelling van Pythagoras?", "\"De stelling van Pythagoras\" heeft 23 letters.", new string[]{"23","3","1","0"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 4 - 2 + 3 * 0 - 3 ?", "", new string[]{"-1","4","-3","0"}));
			vragen.Add(new MultipleChoiceVraag("Hoeveel is 2^10 ?", "", new string[]{"1024","210","-11","16"}));
			vragen.Add (new TrueFalseVraag ("1 - 1 = 0 ?", "", true));
			vragen.Add (new TrueFalseVraag ("6 * 4 = 10 ?", "", false));
			vragen.Add (new TrueFalseVraag ("-1 * -4 = -4 ?", "", false));
			vragen.Add (new TrueFalseVraag ("-7 + 3 = -4 ?", "", true));
			vragen.Add (new TrueFalseVraag ("pi > e ?", "pi = 3,14... e = 2,718...", true));
			KeyValuePair<String, List<Vraag>> subonderwerpKVP = new KeyValuePair<string, List<Vraag>> (subonderwerp, vragen);
			List<KeyValuePair<String, List<Vraag>>> subonderwerpList = new List<KeyValuePair<String, List<Vraag>>> ();
			subonderwerpList.Add (subonderwerpKVP);
			KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>> onderwerpKVP = new KeyValuePair<string, List<KeyValuePair<string, List<Vraag>>>> (onderwerp, subonderwerpList);
			db.Add (onderwerpKVP);
			Singleton.OnlineDatabase = db;
			return true;
		}

		/// <summary>
		/// "Download" vragen van een bepaald onderwerp + subonderwerp.
		/// </summary>
		/// <param name="onderwerp">Onderwerp.</param>
		/// <param name="subonderwerp">Subonderwerp.</param>
//		public void DownloadVragen(string onderwerp, string subonderwerp) {
//			//bestanden kopieren en CheckLocalVragen() gebruiken om in te lezen (niet vragen los kopieren, anders blijven oude, slechte, verwijderde vragen in local staan)
//			string sourcePath = "ms-appx:///Assets/online/" + onderwerp;
//			string targetPath = "ms-appx:///Assets/local/" + onderwerp;
//			if (!System.IO.Directory.Exists(targetPath))
//			{
//				System.IO.Directory.CreateDirectory(targetPath);
//			}
//			try {
//			System.IO.File.Copy(sourcePath + "/" + subonderwerp + ".txt", targetPath + "/" + subonderwerp + ".txt", true);
//			} catch (System.IO.IOException e) {
//				Console.WriteLine("The file could not be overwritten:");
//				Console.WriteLine(e.Message);
//			}
//		}
		public void DownloadVragen(string onderwerp, string subonderwerp) {
			CheckOnlineVragen ();//vult online database
			Singleton.LocalDatabase = Singleton.OnlineDatabase;//kopieert alles van online database naar local
		}

	}
}

