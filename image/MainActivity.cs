using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using System.Drawing;
using Android.Accounts;
using DropboxSync.Android.Client2;
using DropboxSync.Android;
using Android.Graphics;
//using System.Drawing;
using Android.Provider;
using Dropins.Chooser.Android;
using System.Collections.Generic;
using AndroidUri = Android.Net.Uri;
//using EntryItem.Item;

namespace image
{
	[Activity (Label = "image", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity//,  AdapterView.IOnItemClickListener
	{
		DBChooser chooser;
		//ImageView imageView;
		const int dropboxRequest = 0;
		const string dropboxAppKey = "xy6ee27ypb9d6m6";
//		string AppKey = "xy6ee27ypb9d6m6";
//		string AppSecret = "x34ze4s364gqhhc";
		List<image.Item> items;
		private Paint _Paint = new Paint();
		public Bitmap _Bmp;// = null;
		private Canvas _Canvas;
		private System.Drawing.PointF _StartPt = new System.Drawing.PointF();
		ListView listView ;
		Android.Net.Uri imageUri = null;
		string[] values;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			//Account = DBAccountManager.GetInstance (ApplicationContext, AppKey, AppSecret);
			chooser = new DBChooser (dropboxAppKey);
			SetContentView (Resource.Layout.Main);
			Button button = FindViewById<Button> (Resource.Id.myButton);
			//Button button2 = FindViewById<Button> (Resource.Id.myButton2);
			//ImageView imageView = FindViewById<ImageView> (Resource.Id.myImageView);
				
			button.Click += delegate {
				var imageIntent = new Intent ();
				imageIntent.SetType ("image/*");
				imageIntent.SetAction (Intent.ActionGetContent);
				StartActivityForResult (
				Intent.CreateChooser (imageIntent, "Select photo"), 0);
			};
			FindViewById<Button> (Resource.Id.btnDirect).Click += delegate {
				chooser.ForResultType (DBChooser.ResultType.DirectLink).Launch (this, dropboxRequest);
			};

			FindViewById<Button> (Resource.Id.btnPreview).Click += delegate {
				//ListAdapter =  FindViewById<ListView>(Resource.Id.list);
				var ListView = new Intent (this, typeof(ListView));

				StartActivity(ListView);
				//SetContentView(Resource.Layout.build);
				//Context context = new Context();
//				Intent intent = new Intent(this, ListView.GetObject);
//				startActivity(intent);
			};

			items = new List<image.Item> ();

		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);
//			if (requestCode != dropboxRequest)
//				base.OnActivityResult (requestCode, resultCode, data);
			if (resultCode == Result.Ok) {
				if (requestCode == dropboxRequest){
					var imageView = FindViewById<ImageView> (Resource.Id.myImageView);	
					//imageView.SetImageURI (data.Data);
					imageUri = data.Data;
									}
				else {
					var imageView = FindViewById<ImageView> (Resource.Id.myImageView);

					var result = new DBChooser.Result (data);
					//imageView.SetImageURI (result.Link);
					imageUri = result.Link;

				}


			}


			SetContentView (Resource.Layout.imageLoad);


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

		public override bool OnTouchEvent(MotionEvent e)
		{ 

			_Paint = new Paint ();
			_Paint.Color = new Android.Graphics.Color (255, 0, 0);
			_Paint.StrokeWidth = 20;
			_Paint.StrokeCap = Paint.Cap.Round;
			var imageView = FindViewById<ImageView> (Resource.Id.myImageView);
			Bitmap immutableBitmap = MediaStore.Images.Media.GetBitmap(this.ContentResolver, imageUri);
			_Bmp = immutableBitmap.Copy(Bitmap.Config.Argb8888, true);
			_Canvas = new Canvas(_Bmp);
			imageView.SetImageBitmap (_Bmp);
				switch (e.Action)
				{

				default:
				{
					_StartPt.X=e.RawX;
					_StartPt.Y=e.RawY;	
					Console.WriteLine ("inside default:{0}","default");
					DrawPoint (_Canvas);
					break;
				}
				}



			return true;

		}
		private void DrawPoint(Canvas canvas)
		{
			var metrics = Resources.DisplayMetrics;
			var widthInPixels = metrics.WidthPixels;
			var heightInPixels = metrics.HeightPixels;
			var x = canvas.Width;
			var y = canvas.Height;
			_StartPt.X  = (_StartPt.X*x)/widthInPixels ;
			_StartPt.Y = (_StartPt.Y*y)/heightInPixels ; 
			canvas.DrawPoint(_StartPt.X,_StartPt.Y, _Paint);

		}







	}
}


