using System;

namespace DBChooserApp.Android
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

