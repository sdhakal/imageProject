using System;

namespace DBChooserApp.Android
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

		public override bool IsSection {
			get {
				return false;
			}
		}
	}
}

