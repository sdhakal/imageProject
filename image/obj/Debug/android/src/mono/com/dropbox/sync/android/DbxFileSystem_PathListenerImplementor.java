package mono.com.dropbox.sync.android;


public class DbxFileSystem_PathListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.dropbox.sync.android.DbxFileSystem.PathListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onPathChange:(Lcom/dropbox/sync/android/DbxFileSystem;Lcom/dropbox/sync/android/DbxPath;Lcom/dropbox/sync/android/DbxFileSystem$PathListener$Mode;)V:GetOnPathChange_Lcom_dropbox_sync_android_DbxFileSystem_Lcom_dropbox_sync_android_DbxPath_Lcom_dropbox_sync_android_DbxFileSystem_PathListener_Mode_Handler:DropboxSync.Android.DBFileSystem/IPathListenerInvoker, DropboxSync.Android\n" +
			"";
		mono.android.Runtime.register ("DropboxSync.Android.DBFileSystem/IPathListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DbxFileSystem_PathListenerImplementor.class, __md_methods);
	}


	public DbxFileSystem_PathListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DbxFileSystem_PathListenerImplementor.class)
			mono.android.TypeManager.Activate ("DropboxSync.Android.DBFileSystem/IPathListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onPathChange (com.dropbox.sync.android.DbxFileSystem p0, com.dropbox.sync.android.DbxPath p1, com.dropbox.sync.android.DbxFileSystem.PathListener.Mode p2)
	{
		n_onPathChange (p0, p1, p2);
	}

	private native void n_onPathChange (com.dropbox.sync.android.DbxFileSystem p0, com.dropbox.sync.android.DbxPath p1, com.dropbox.sync.android.DbxFileSystem.PathListener.Mode p2);

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
