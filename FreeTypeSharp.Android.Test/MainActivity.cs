using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using System;
using static FreeTypeSharp.FT;

namespace FreeTypeSharp.Android.Test
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected unsafe override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var textView1 = FindViewById<TextView>(Resource.Id.textView1);

            var library = new FreeTypeLibrary();
            int major, minor, patch;
            FT_Library_Version(library.Native, &major, &minor, &patch);
            textView1.Text = $"FreeType version: {major}.{minor}.{patch}";
        }
    }
}