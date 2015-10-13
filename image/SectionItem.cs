
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
	public class SectionItem : Item
	{
		public string Title { get; private set; }

		public SectionItem (string title)
		{
			if (title == null)
				title = string.Empty;
			Title = title;
		}
	}
}

