package md5ee7e751c31e96d3de0ad0f05a3ed1bd4;


public class FilmDetailsActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("StarwarsApp.Activities.FilmDetailsActivity, StarwarsApp", FilmDetailsActivity.class, __md_methods);
	}


	public FilmDetailsActivity ()
	{
		super ();
		if (getClass () == FilmDetailsActivity.class)
			mono.android.TypeManager.Activate ("StarwarsApp.Activities.FilmDetailsActivity, StarwarsApp", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
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
