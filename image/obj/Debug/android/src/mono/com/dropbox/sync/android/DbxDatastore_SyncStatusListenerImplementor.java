package mono.com.dropbox.sync.android;


public class DbxDatastore_SyncStatusListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.dropbox.sync.android.DbxDatastore.SyncStatusListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onDatastoreStatusChange:(Lcom/dropbox/sync/android/DbxDatastore;)V:GetOnDatastoreStatusChange_Lcom_dropbox_sync_android_DbxDatastore_Handler:DropboxSync.Android.DBDatastore/ISyncStatusListenerInvoker, DropboxSync.Android\n" +
			"";
		mono.android.Runtime.register ("DropboxSync.Android.DBDatastore/ISyncStatusListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DbxDatastore_SyncStatusListenerImplementor.class, __md_methods);
	}


	public DbxDatastore_SyncStatusListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DbxDatastore_SyncStatusListenerImplementor.class)
			mono.android.TypeManager.Activate ("DropboxSync.Android.DBDatastore/ISyncStatusListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onDatastoreStatusChange (com.dropbox.sync.android.DbxDatastore p0)
	{
		n_onDatastoreStatusChange (p0);
	}

	private native void n_onDatastoreStatusChange (com.dropbox.sync.android.DbxDatastore p0);

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
