package mono.com.dropbox.sync.android;


public class DbxAccount_ListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.dropbox.sync.android.DbxAccount.Listener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onAccountChange:(Lcom/dropbox/sync/android/DbxAccount;)V:GetOnAccountChange_Lcom_dropbox_sync_android_DbxAccount_Handler:DropboxSync.Android.DBAccount/IListenerInvoker, DropboxSync.Android\n" +
			"";
		mono.android.Runtime.register ("DropboxSync.Android.DBAccount/IListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DbxAccount_ListenerImplementor.class, __md_methods);
	}


	public DbxAccount_ListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DbxAccount_ListenerImplementor.class)
			mono.android.TypeManager.Activate ("DropboxSync.Android.DBAccount/IListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onAccountChange (com.dropbox.sync.android.DbxAccount p0)
	{
		n_onAccountChange (p0);
	}

	private native void n_onAccountChange (com.dropbox.sync.android.DbxAccount p0);

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
