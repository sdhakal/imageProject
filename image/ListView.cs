
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Android.App.
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace image
{
	[Activity (Label = "ListView")]			
	public class ListView : Activity//, IEnumerable
	{
		public List<string[]> infoList= new List<string[]>();
		//string[] values;
		//Dialog dialog;
		protected override void OnCreate (Bundle bundle)
		{
			
			base.OnCreate (bundle);
			//string text = Intent.GetStringArrayListExtra ("MyData") ?? "Data not available";
			SetContentView (Resource.Layout.listview);
			FindViewById<Button> (Resource.Id.btnCreate).Click += delegate {
				Console.WriteLine("check{0}","inside btncreate");
				Dialog dialog = new Dialog(this);
				dialog.SetTitle("form");
//				dialog.SetContentView(Resource.Layout.build);
				//var alert = new AlertDialog.Builder(Forms.Context);
//				AlertDialog.Builder dialog= new AlertDialog.Builder(this,Android.App.AlertDialog.ThemeHoloLight);
//				dialog.SetView (FindViewById<View> (Resource.Layout.build));
				//dialog.Create();
				dialog.Show();
			};

		}

		//public 
		public void addMethod(){


			Information information= new Information (FindViewById<EditText>(Resource.Id.editTextName).Text,FindViewById<EditText>(Resource.Id.editTextAddress).Text,FindViewById<EditText>(Resource.Id.editTextNumber).Text);


		}


//		protected override void OnListItemClick(ListView l, View v, int position, long id)
//		{
//			base.OnListItemClick(l, v, position, id);
//			var t = values[position];
//			SetContentView (Resource.Layout.infoview);
//			//Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();
//		}
	}
}

