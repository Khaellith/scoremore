package scoremore;


public class ResultaatBekijken
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("scoremore.ResultaatBekijken, scoremore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ResultaatBekijken.class, __md_methods);
	}


	public ResultaatBekijken () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ResultaatBekijken.class)
			mono.android.TypeManager.Activate ("scoremore.ResultaatBekijken, scoremore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
