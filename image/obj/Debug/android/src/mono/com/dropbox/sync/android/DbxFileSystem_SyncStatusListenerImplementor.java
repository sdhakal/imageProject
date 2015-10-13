package mono.com.dropbox.sync.android;


public class DbxFileSystem_SyncStatusListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.dropbox.sync.android.DbxFileSystem.SyncStatusListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onSyncStatusChange:(Lcom/dropbox/sync/android/DbxFileSystem;)V:GetOnSyncStatusChange_Lcom_dropbox_sync_android_DbxFileSystem_Handler:DropboxSync.Android.DBFileSystem/ISyncStatusListenerInvoker, DropboxSync.Android\n" +
			"";
		mono.android.Runtime.register ("DropboxSync.Android.DBFileSystem/ISyncStatusListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DbxFileSystem_SyncStatusListenerImplementor.class, __md_methods);
	}


	public DbxFileSystem_SyncStatusListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DbxFileSystem_SyncStatusListenerImplementor.class)
			mono.android.TypeManager.Activate ("DropboxSync.Android.DBFileSystem/ISyncStatusListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onSyncStatusChange (com.dropbox.sync.android.DbxFileSystem p0)
	{
		n_onSyncStatusChange (p0);
	}

	private native void n_onSyncStatusChange (com.dropbox.sync.android.DbxFileSystem p0);

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
