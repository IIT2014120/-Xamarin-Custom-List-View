using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Xamarin_Custom_List_View
{
    [Activity(Label = "Xamarin_Custom_List_View", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<Person> mItems;
        private ListView mListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mItems = new List<Person>();
            mItems.Add(new Person() { firstName = "Don", lastName = "Corleone", Age = "50", Gender = "male" });
            mItems.Add(new Person() { firstName = "Tom", lastName = "Tom", Age = "35", Gender = "male" });
            mItems.Add(new Person() { firstName = "Sally", lastName = "Langston", Age = "88", Gender = "female" });

            mListView = FindViewById<ListView>(Resource.Id.myListView);

            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);
            mListView.Adapter = adapter;
            mListView.ItemClick += mListView_ItemClick;
            mListView.ItemClick += mListView_ItemClick2;
            mListView.ItemLongClick += mListView_ItemLongClick;
        }

        void mListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].firstName);
        }

        void mListView_ItemClick2(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].Age);
        }


        void mListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].lastName);
        }
    }
}

