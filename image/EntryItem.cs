
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace image
{
	public class EntryItem : Item
	{
		public string Title { get; private set; }
		public string Subtitle { get; private set; }

		public EntryItem (string title, string subtitle)
		{
			if (title == null)
				title = string.Empty;

			if (subtitle == null)
				subtitle = string.Empty;

			Title = title;
			Subtitle = subtitle;
		}
		public EntryItem()
		{
		}

		public override bool IsSection {
			get {
				return false;
			}
		}
	}
}

