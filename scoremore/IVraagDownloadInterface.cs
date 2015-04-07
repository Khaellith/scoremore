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
		void DownloadVragen();
	}

	class VragenDownloader : IVraagDownloadInterface
	{
		bool CheckVragen(String type) {
			string pad;
			if (type == "online") {
				pad = "assets/online/";
			} else {
				pad = "assets/local/";
			}
			List<KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>>> database = new List<KeyValuePair<string, List<KeyValuePair<string, List<Vraag>>>>> ();
			//AssetManager am = context.getAssets();
			//TODO: loop om door alle mappen binnen /assets/local te bladeren

			//string pad = "assets/local/";
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
						string[] antwoorden;
						bool antwoord;
						string[] onderdeelSeparator = {"\n"};
						string[] vraagonderdelen = vraag.Split(onderdeelSeparator, StringSplitOptions.None);
						foreach (var onderdeel in vraagonderdelen) {
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
					foreach (var onderwerpKVP in database) {
						if (onderwerpKVP.Key == onderwerp) {
							onderwerpGevonden = true;
							foreach (var subonderwerpKVP in onderwerpKVP.Value) {
								if (subonderwerpKVP.Key == subonderwerp) {
									subonderwerpGevonden = true;
									subonderwerpKVP.Value = vragenlijst;
								}
							}
							if (!subonderwerpGevonden) {
								onderwerpKVP.Value.Add(dbEntry);
							}
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
			//TODO: database opslaan (als return value?, als static variable?)
		}

		bool CheckLocalVragen() {
			return CheckVragen("local");
		}

		bool CheckOnlineVragen() {
			return CheckVragen("online");
		}

		void DownloadVragen() {
			//TODO: loop om door alle mappen binnen /assets/online te bladeren en naar /assets/local te kopieren
			//bestanden kopieren en CheckLocalVragen() gebruiken om in te lezen (anders blijven oude, slechte, verwijderde vragen in local staan)
		}
	}
}

