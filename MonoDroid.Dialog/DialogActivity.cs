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

namespace MonoDroid.Dialog
{
	public class DialogActivity : ListActivity
	{
		public RootElement Root
		{
			get;
			set;
		}

		public DialogAdapter DialogAdapter
		{
			get;
			private set;
		}

        /// <summary>
        /// A callback which is called when the activity is being created.
        /// Subclass's corresponding method needs to call OnCreate after the initialzation of Root property
        /// </summary>
        /// <param name='savedInstanceState'>
        /// Saved instance state.
        /// </param>
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
            this.DialogAdapter = new DialogAdapter(this, Root);
			this.ListAdapter = this.DialogAdapter;
            this.ListView.ItemClick += ListView_ItemClick;
			this.ListView.ItemLongClick += ListView_ItemLongClick;
		}

		void ListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
		{
			var elem = this.DialogAdapter[e.Position] as Element;

			if (elem != null && elem.LongClick != null)
				elem.LongClick();
		}

		void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var elem = this.DialogAdapter[e.Position] as Element;

			if (elem != null && elem.Click != null)
				elem.Click();
		}

	}
}