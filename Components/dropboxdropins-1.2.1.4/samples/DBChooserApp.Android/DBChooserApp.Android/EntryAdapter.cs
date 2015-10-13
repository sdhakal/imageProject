using System;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;
using Android.Views;
using Android.App;


namespace DBChooserApp.Android
{
	public class EntryAdapter : ArrayAdapter<Item>
	{
		Activity context;
		List<Item> items;

		public EntryAdapter (Activity cont, List<Item> i) : base (cont, 0, i.ToArray ())
		{
			context = cont;
			items = i;
		}

		public override int Count {
			get {
				return items.Count;
			}
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			Item item = items [position];

			if (item == null)
				return view;

			if (item is SectionItem) {
				SectionItem section = item as SectionItem;

				view = context.LayoutInflater.Inflate (Android.Resource.Layout.list_item_section, null);
				view.FindViewById<TextView> (Android.Resource.Id.lblTitle).Text = section.Title;
			} else {
				EntryItem entry = item as EntryItem;

				view = context.LayoutInflater.Inflate (Android.Resource.Layout.list_item_entry, null);
				view.FindViewById<TextView> (Android.Resource.Id.lblTitle).Text = entry.Title;
				view.FindViewById<TextView> (Android.Resource.Id.lblSubtitle).Text = entry.Subtitle;
			}

			return view;
		}
	}
}

