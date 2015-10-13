using System;
using DropBoxSync.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

namespace DropBoxSyncSampleMTD
{
	public class NoteController : UIViewController
	{
		public UIActivityIndicatorView ActivityIndicator { get; set; }
		public DBFile File { get; set; }
		public UITextView TextView { get; set; }
		public bool TextViewLoaded { get; set; }
		public NSTimer WriteTimer { get; set; }
		
		public NoteController (DBFile file)
		{
			File = file;
			NavigationItem.Title = File.Info.Path.Name;

			#if __UNIFIED__
			NavigationItem.RightBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.FastForward, this, new ObjCRuntime.Selector ("didPressUpdate"));
			#else
			NavigationItem.RightBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.FastForward, this, new MonoTouch.ObjCRuntime.Selector ("didPressUpdate"));
			#endif
		}
		
		public NoteController (IntPtr handle) : base (handle)
		{
			
		}
		
		void UnloadViews ()
		{
			ActivityIndicator = null;
			TextView = null;
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			TextView = new UITextView (View.Bounds);
			TextView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleHeight;
			TextView.Changed += (sender, e) => {
				if (WriteTimer != null)
					WriteTimer.Invalidate ();

				#if __UNIFIED__
				WriteTimer = NSTimer.CreateScheduledTimer (3, this, new ObjCRuntime.Selector ("saveChanges"), null, false);
				#else
				WriteTimer = NSTimer.CreateScheduledTimer (3, this, new MonoTouch.ObjCRuntime.Selector ("saveChanges"), null, false);
				#endif
			};
			View.AddSubview (TextView);
			ActivityIndicator = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.Gray);
			CGRect frame = ActivityIndicator.Bounds;
			frame.X = (float) Math.Floor (View.Bounds.Size.Width / 2 - frame.Size.Width / 2);
			frame.Y = (float) Math.Floor (View.Bounds.Size.Height / 2 - frame.Size.Height / 2);
			ActivityIndicator.Frame = frame;
			View.AddSubview (ActivityIndicator);
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			UnloadViews();
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			File.AddObserver (this, ()=> Reload () );
			NavigationController.SetToolbarHidden (true, true);
			Reload ();
		}
		
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			File.RemoveObserver (this);
			SaveChanges ();
			File.Close();
		}
		
		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return toInterfaceOrientation == UIInterfaceOrientation.Portrait ? true : false;
		}
		
		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations ()
		{
			return UIInterfaceOrientationMask.Portrait;
		}
		
		public override UIInterfaceOrientation PreferredInterfaceOrientationForPresentation ()
		{
			return UIInterfaceOrientation.Portrait;
		}
		
		void Reload ()
		{
			bool updateEnabled = false;
			DBError error;
			if (File.Status.Cached) {
				if (!TextViewLoaded) {
					TextViewLoaded = true;
					string contents = File.ReadString (out error);
					TextView.Text = contents;
				}
				ActivityIndicator.StopAnimating ();
				TextView.Hidden = false;
				
				if (File.NewerStatus != null && File.NewerStatus.Cached) 
					updateEnabled = true;
			} else {
				ActivityIndicator.StartAnimating ();
				TextView.Hidden = true;
			}
			NavigationItem.RightBarButtonItem.Enabled = updateEnabled;
		}
		
		[Export ("saveChanges")]
		void SaveChanges ()
		{
			if (WriteTimer == null) return;
			DBError error;
			WriteTimer.Invalidate ();
			WriteTimer = null;
			File.WriteString(TextView.Text, out error);
		}
		
		[Export ("didPressUpdate")]
		void DidPressUpdate ()
		{
			DBError error;
			File.Update (out error);
			TextViewLoaded = false;
			Reload ();
		}
	}
}

