using System;

#if __UNIFIED__
using UIKit;
using CoreGraphics;
#else
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Drawing;

using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

namespace MonkeyBox
{
	public class MonkeyView : UIControl
	{
		UIImageView image;
		public Monkey Monkey { get; private set; }
		public MonkeyView (Monkey monkey)
		{
			Monkey = monkey;
			image = new UIImageView (UIImage.FromBundle (monkey.Name));
			this.AddSubview (image);
			this.Frame = image.Frame;
		}

		public PlayGroundView CurrentPlayground {get;set;}

		public override void MovedToSuperview ()
		{
			base.MovedToSuperview ();
			if (this.Superview is PlayGroundView)
				CurrentPlayground = (PlayGroundView)this.Superview;
		}

		#if __UNIFIED__
		public override void TouchesBegan (Foundation.NSSet touches, UIEvent evt)
		#else
		public override void TouchesBegan (MonoTouch.Foundation.NSSet touches, UIEvent evt)
		#endif
		{
			base.TouchesBegan (touches, evt);
			CurrentPlayground.CurrentMonkey = this;
		}

		public void Update(Monkey monkey, CGRect bounds)
		{
			var transform = CGAffineTransform.MakeIdentity ();
			transform.Rotate (monkey.Rotation);
			transform.Scale (monkey.Scale, monkey.Scale);
			Transform = transform;

			// Convert location from top/left to center coords.
			var widthOffset = Frame.Width * 0.5f;
			var heightOffset = Frame.Width * 0.5f;

			var x = bounds.Width * monkey.X;
			var y = bounds.Height * monkey.Y;

			Center = new CGPoint (x + widthOffset, y + heightOffset);
		}

		public void UpdateMonkey(CGRect bounds)
		{
			// Save location in top/left, not center,
			// in order to make it easier to draw the
			// monkeys on Android and other platforms.

			var widthOffset = Frame.Width * 0.5f;
			var heightOffset = Frame.Width * 0.5f;

			Monkey.X = (Center.X - widthOffset) / bounds.Width;
			Monkey.Y = (Center.Y - heightOffset) / bounds.Height;

			Monkey.Scale = Transform.GetScale ();
			Monkey.Rotation = Transform.GetRotation ();
		}
	}
}

