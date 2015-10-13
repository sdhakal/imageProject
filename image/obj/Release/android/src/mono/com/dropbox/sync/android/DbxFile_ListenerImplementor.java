package mono.com.dropbox.sync.android;


public class DbxFile_ListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.dropbox.sync.android.DbxFile.Listener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onFileChange:(Lcom/dropbox/sync/android/DbxFile;)V:GetOnFileChange_Lcom_dropbox_sync_android_DbxFile_Handler:DropboxSync.Android.DBFile/IListenerInvoker, DropboxSync.Android\n" +
			"";
		mono.android.Runtime.register ("DropboxSync.Android.DBFile/IListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DbxFile_ListenerImplementor.class, __md_methods);
	}


	public DbxFile_ListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DbxFile_ListenerImplementor.class)
			mono.android.TypeManager.Activate ("DropboxSync.Android.DBFile/IListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onFileChange (com.dropbox.sync.android.DbxFile p0)
	{
		n_onFileChange (p0);
	}

	private native void n_onFileChange (com.dropbox.sync.android.DbxFile p0);

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
