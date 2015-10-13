package mono.com.dropbox.sync.android;


public class DbxDatastoreManager_ListListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.dropbox.sync.android.DbxDatastoreManager.ListListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onDatastoreListChange:(Lcom/dropbox/sync/android/DbxDatastoreManager;)V:GetOnDatastoreListChange_Lcom_dropbox_sync_android_DbxDatastoreManager_Handler:DropboxSync.Android.DBDatastoreManager/IListListenerInvoker, DropboxSync.Android\n" +
			"";
		mono.android.Runtime.register ("DropboxSync.Android.DBDatastoreManager/IListListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DbxDatastoreManager_ListListenerImplementor.class, __md_methods);
	}


	public DbxDatastoreManager_ListListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DbxDatastoreManager_ListListenerImplementor.class)
			mono.android.TypeManager.Activate ("DropboxSync.Android.DBDatastoreManager/IListListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onDatastoreListChange (com.dropbox.sync.android.DbxDatastoreManager p0)
	{
		n_onDatastoreListChange (p0);
	}

	private native void n_onDatastoreListChange (com.dropbox.sync.android.DbxDatastoreManager p0);

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
