package scoremore;


public class VragenDownloaden
<<<<<<< HEAD
	extends android.app.Activity
=======
	extends android.app.ListActivity
>>>>>>> origin/master
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
<<<<<<< HEAD
=======
			"n_onListItemClick:(Landroid/widget/ListView;Landroid/view/View;IJ)V:GetOnListItemClick_Landroid_widget_ListView_Landroid_view_View_IJHandler\n" +
<<<<<<< HEAD
			"n_onBackPressed:()V:GetOnBackPressedHandler\n" +
=======
>>>>>>> origin/master
>>>>>>> origin/master
			"";
		mono.android.Runtime.register ("scoremore.VragenDownloaden, scoremore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", VragenDownloaden.class, __md_methods);
	}


	public VragenDownloaden () throws java.lang.Throwable
	{
		super ();
		if (getClass () == VragenDownloaden.class)
			mono.android.TypeManager.Activate ("scoremore.VragenDownloaden, scoremore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

<<<<<<< HEAD
=======

	public void onListItemClick (android.widget.ListView p0, android.view.View p1, int p2, long p3)
	{
		n_onListItemClick (p0, p1, p2, p3);
	}

	private native void n_onListItemClick (android.widget.ListView p0, android.view.View p1, int p2, long p3);

<<<<<<< HEAD

	public void onBackPressed ()
	{
		n_onBackPressed ();
	}

	private native void n_onBackPressed ();

=======
>>>>>>> origin/master
>>>>>>> origin/master
	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
