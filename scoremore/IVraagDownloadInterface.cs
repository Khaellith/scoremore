using System;
using Android.Content.Res;

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
		bool CheckLocalVragen() {
			//AssetManager am = context.getAssets();

		}

		bool CheckOnlineVragen() {
			
		}

		void DownloadVragen() {
			
		}
	}
}

