This component allows you to add Dropbox Chooser Drop-in into your Xamarin.iOS app with a few lines of code.

Dropbox Chooser on iOS
======================

## Creating a Url scheme

The Chooser coordinates with the Dropbox app to allow the user to select files without having to worry about the usual authorization flow. But in order to smoothly hand the user back to your app, you need to add a unique URL scheme that Dropbox can call. You'll need to configure your project to add one:

1. Double-click on your app's Info.plist file
2. Select the Advanced Tab
3. Find the Url Types Section 
4. Click Add URL Type and set URL Schemes to `db-DropboxKey` (i.e. "db-aaa111bbb2222").

You can get your key from [Dropbox App Console](https://www.dropbox.com/developers/apps).

### AppDelegate.cs

```csharp
using Dropins.Chooser.iOS;
//...

public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
{
	if (DBChooser.DefaultChooser.HandleOpenUrl (url)) {
		// This was a Chooser response and handleOpenURL automatically ran the
		// completion handler	
		return true;
	}
	return false;
}

```

### YourViewController.cs

```csharp
using Dropins.Chooser.iOS;
//...

public override void ViewDidLoad ()
{
	base.ViewDidLoad ();

	// Create the button that will call Dropbox Chooser.
	btnChooser = UIButton.FromType (UIButtonType.RoundedRect);
	btnChooser.Frame = new System.Drawing.RectangleF (20, 225, 280, 30);
	btnChooser.SetTitle ("Choose File", UIControlState.Normal);

	// Open the chooser when the user taps the button
	btnChooser.TouchUpInside += (sender, e) => {

		// This will open the chooser view
		DBChooser.DefaultChooser.OpenChooser (DBChooserLinkType.Direct, this, (results) => {
			// results is null if the user cancels
			if (results == null)
				new UIAlertView ("Cancelled", "User cancelled!", null, "Continue").Show ();
			// Do something with the results
			else {
				string fileName = results[0].Name;
				new UIAlertView ("File Selected", fileName , null, "Continue").Show ();
			} 
		});
	};
}

```

## Link types

The Chooser can be configured to return one of two link types.

* **DBChooserLinkType.Preview**: Preview links point to a human-friendly preview page of a file and are great for sharing. You can read more about links to Dropbox files in our Help Center. Note that users may disable this link at a later point if they choose.

* **DBChooserLinkType.Direct**: Links point directly to the contents of the file and are useful for downloading the file itself. Unlike preview links, however, they will expire after four hours, so make sure to download the contents of the file immediately after the file is chosen. Direct links also support CORS, which allows you to read the file information directly in the browser using client-side JavaScript.

## Handling multiple app keys

The example uses the defaultChooser, which is created and initialized with the URL Scheme you registered during setup. You may have a project that requires multiple app keys because it also uses the Core or Sync API. In this case, you'll need to explicitly initialize your own instance of the Chooser with the right app key by using the constructor that takes the string key as parameter.

# News: iOS Unified API Support

Dropbox Chooser on Android
==========================

## Triggering the Chooser

Your app should give the user a button or action that asks them to select a file from Dropbox. You'll need the App key. You can get your key from [Dropbox App Console](https://www.dropbox.com/developers/apps).

```csharp
DBChooser chooser;
const int dropboxRequest = 0; // You can change this if needed
const string dropboxAppKey = "APP_KEY";

protected override void OnCreate (Bundle bundle)
{
	base.OnCreate (bundle);

	// Set our view from the "main" layout resource
	SetContentView (Resource.Layout.Main);

	chooser = new DBChooser (dropboxAppKey);

	// Get our button from the layout resource,
	// and attach an event to it
	FindViewById<Button> (Resource.Id.btnDirect).Click += delegate {
		// It could be:
		// DBChooser.ResultType.DirectLink
		// DBChooser.ResultType.PreviewLink or
		// DBChooser.ResultType.FileContent
		chooser.ForResultType (DBChooser.ResultType.Type).Launch (this, dropboxRequest);
	};
}
```

The Chooser coordinates with the Dropbox app to allow the user to select files without having to worry about the usual authorization flow. In order to handle the response when the user returns to your app, you'll need to override **OnActivityResult** method:

```csharp
protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
{
	if (requestCode != dropboxRequest)
		base.OnActivityResult (requestCode, resultCode, data);

	if (resultCode != Result.Ok) {
		// Failed or was cancelled by the user.
	}
	
	var result = new DBChooser.Result (data);

	// Handle the result

}
```

## Link types

The Chooser can be configured to return one of three link types.

**ResultType.PreviewLink** links are the default type of link returned by the Chooser. Preview links point to a human-friendly preview page of a file and are great for sharing. You can read more about links to Dropbox files in our Help Center. Note that users may disable this link at a later point if they choose.

**ResultType.DirectLink** links point directly to the contents of the file and are useful for downloading the file itself. Unlike preview links, however, they will expire after four hours, so make sure to download the contents of the file immediately after the file is chosen.

**ResultType.FileContent** links (Android only) point to the actual file on the local device and let your app take advantage of files cached by the Dropbox app. However, these files are temporary and can be cleaned up by the operating system at any point, so you should copy it and manage it within your app if you need to keep the contents of a file.