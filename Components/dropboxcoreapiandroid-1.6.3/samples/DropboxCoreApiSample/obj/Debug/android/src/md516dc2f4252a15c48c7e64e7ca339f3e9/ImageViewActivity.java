package md516dc2f4252a15c48c7e64e7ca339f3e9;


public class ImageViewActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onStart:()V:GetOnStartHandler\n" +
			"";
		mono.android.Runtime.register ("DropboxCoreApiSample.ImageViewActivity, DropboxCoreApiSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ImageViewActivity.class, __md_methods);
	}


	public ImageViewActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ImageViewActivity.class)
			mono.android.TypeManager.Activate ("DropboxCoreApiSample.ImageViewActivity, DropboxCoreApiSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onStart ()
	{
		n_onStart ();
	}

	private native void n_onStart ();

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
