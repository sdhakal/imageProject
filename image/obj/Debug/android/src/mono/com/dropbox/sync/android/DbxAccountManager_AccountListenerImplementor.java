package mono.com.dropbox.sync.android;


public class DbxAccountManager_AccountListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.dropbox.sync.android.DbxAccountManager.AccountListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onLinkedAccountChange:(Lcom/dropbox/sync/android/DbxAccountManager;Lcom/dropbox/sync/android/DbxAccount;)V:GetOnLinkedAccountChange_Lcom_dropbox_sync_android_DbxAccountManager_Lcom_dropbox_sync_android_DbxAccount_Handler:DropboxSync.Android.DBAccountManager/IAccountListenerInvoker, DropboxSync.Android\n" +
			"";
		mono.android.Runtime.register ("DropboxSync.Android.DBAccountManager/IAccountListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DbxAccountManager_AccountListenerImplementor.class, __md_methods);
	}


	public DbxAccountManager_AccountListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DbxAccountManager_AccountListenerImplementor.class)
			mono.android.TypeManager.Activate ("DropboxSync.Android.DBAccountManager/IAccountListenerImplementor, DropboxSync.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onLinkedAccountChange (com.dropbox.sync.android.DbxAccountManager p0, com.dropbox.sync.android.DbxAccount p1)
	{
		n_onLinkedAccountChange (p0, p1);
	}

	private native void n_onLinkedAccountChange (com.dropbox.sync.android.DbxAccountManager p0, com.dropbox.sync.android.DbxAccount p1);

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
