using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AndroidUri = Android.Net.Uri;

using Dropins.Chooser.Android;
using System.Collections.Generic;

namespace DBChooserApp.Android
{
	[Activity (Label = "DBChooserApp.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, AdapterView.IOnItemClickListener
	{
		DBChooser chooser;
		const int dropboxRequest = 0;
		const string dropboxAppKey = "YOUR_APP_KEY";
		List<Item> items;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			chooser = new DBChooser (dropboxAppKey);

			// Get our button from the layout resource,
			// and attach an event to it
			FindViewById<Button> (Resource.Id.btnDirect).Click += delegate {
				chooser.ForResultType (DBChooser.ResultType.DirectLink).Launch (this, dropboxRequest);
			};

			FindViewById<Button> (Resource.Id.btnPreview).Click += delegate {
				chooser.ForResultType (DBChooser.ResultType.PreviewLink).Launch (this, dropboxRequest);
			};

			FindViewById<Button> (Resource.Id.btnLocal).Click += delegate {
				chooser.ForResultType (DBChooser.ResultType.FileContent).Launch (this, dropboxRequest);
			};

			items = new List<Item> ();
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			items.Clear ();

			if (requestCode != dropboxRequest)
				base.OnActivityResult (requestCode, resultCode, data);

			if (resultCode != Result.Ok) {
				Toast.MakeText (this, "Failed or was cancelled by the user.", ToastLength.Long).Show ();
				return;
			}

			var result = new DBChooser.Result (data);

			items.Add (new SectionItem ("METADATA"));
			items.Add (new EntryItem ("Name", result.Name));
			items.Add (new EntryItem ("Size of bytes", result.Size.ToString ()));
			items.Add (new EntryItem ("Icon", result.Icon.ToString ()));

			items.Add (new SectionItem ("LINKS AND THUMBNAILS"));
			items.Add (new EntryItem ("Link", result.Link.ToString ()));

			var thumbnails = result.Thumbnails;

			foreach (var thumbnail in thumbnails)
				items.Add (new EntryItem (thumbnail.Key, thumbnail.Value.ToString ()));

			EntryAdapter adapter = new EntryAdapter (this, items);

			FindViewById<ListView> (Resource.Id.lstData).Adapter = adapter;
			FindViewById<ListView> (Resource.Id.lstData).OnItemClickListener = this;
		}

		public void OnItemClick (AdapterView parent, View view, int position, long id)
		{
			Item item = items [position];

			if (item is SectionItem)
				return;

			EntryItem entry = item as EntryItem;

			try {
				var uri = AndroidUri.Parse (entry.Subtitle);
				var intent = new Intent (Intent.ActionView, uri);
				StartActivity (intent);
			} catch (Exception) {
				
			}
		}
	}
}


