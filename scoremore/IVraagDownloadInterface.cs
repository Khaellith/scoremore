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

	class VragenDownloader : IVraagDownloadInterface
	{
		/// <summary>
		/// Leest .txt files om local of "online" vragendatabase op te bouwen.
		/// </summary>
		/// <returns><c>true</c>, als database succesvol wordt opgebouwd, <c>false</c> als het .txt bestand niet gelezen kan worden.</returns>
		/// <param name="type">Type database (local/online).</param>
		bool CheckVragen(String type) {
			string pad;
			List<KeyValuePair<String, List<KeyValuePair<String, List<Vraag>>>>> database;
			if (type == "online") {
				pad = "ms-appx:///Assets/online/";
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
						string[] antwoorden;
						bool antwoord;
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
		}

		/// <summary>
		/// Bouwt local vragendatabase op uit .txt files.
		/// </summary>
		/// <returns><c>true</c>, als database succesvol wordt opgebouwd, <c>false</c> als het .txt bestand niet gelezen kan worden.</returns>
		bool CheckLocalVragen() {
			return CheckVragen("local");
		}

		/// <summary>
		/// Bouwt "online" vragendatabase op uit .txt files.
		/// </summary>
		/// <returns><c>true</c>, als database succesvol wordt opgebouwd, <c>false</c> als het .txt bestand niet gelezen kan worden.</returns>
		bool CheckOnlineVragen() {
			return CheckVragen("online");
		}

		/// <summary>
		/// "Download" vragen van een bepaald onderwerp + subonderwerp.
		/// </summary>
		/// <param name="onderwerp">Onderwerp.</param>
		/// <param name="subonderwerp">Subonderwerp.</param>
		void DownloadVragen(string onderwerp, string subonderwerp) {
			//bestanden kopieren en CheckLocalVragen() gebruiken om in te lezen (niet vragen los kopieren, anders blijven oude, slechte, verwijderde vragen in local staan)
			string sourcePath = "ms-appx:///Assets/online/" + onderwerp;
			string targetPath =  "ms-appx:///Assets/local/" + onderwerp;
			if (!System.IO.Directory.Exists(targetPath))
			{
				System.IO.Directory.CreateDirectory(targetPath);
			}
			try {
			System.IO.File.Copy(sourcePath + "/" + subonderwerp + ".txt", targetPath + "/" + subonderwerp + ".txt", true);
			} catch (System.IO.IOException e) {
				Console.WriteLine("The file could not be overwritten:");
				Console.WriteLine(e.Message);
			}
		}
	}
}

