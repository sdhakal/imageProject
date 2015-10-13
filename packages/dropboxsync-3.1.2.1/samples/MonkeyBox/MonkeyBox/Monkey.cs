using System;
using System.Collections.Generic;

#if !__UNIFIED__
using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

namespace MonkeyBox
{
	public class Monkey
	{
		static Random random = new Random();
		public Monkey ()
		{
			Scale = (float)Math.Max(random.NextDouble(),.33);
			X = (nfloat)random.NextDouble();
			Y = (nfloat)random.NextDouble();
		}
		public string Name {get;set;}
		public nfloat Rotation {get;set;}
		public nfloat Scale {get;set;}
		public nfloat X {get;set;}
		public nfloat Y {get;set;}
		public nint Z {get;set;}

		public static Monkey[] GetAllMonkeys()
		{
			return new Monkey[] {
				new Monkey{
					Name = "Fred",
				},
				new Monkey{
					Name = "George",
				},
				new Monkey {
					Name = "Hootie",
				},
				new Monkey {
					Name = "Julian",
				},
				new Monkey {
					Name = "Nim",
				},
				new Monkey {
					Name = "Pepe",
				}
			};
		}
	}
}

