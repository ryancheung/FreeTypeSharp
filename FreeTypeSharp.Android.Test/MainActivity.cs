using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using System;
using FreeTypeSharp;
using static FreeTypeSharp.Native.FT;

namespace FreeTypeSharp.Android.Test
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var library = new FreeTypeLibrary();
            FT_Library_Version(library.Native, out var major, out var minor, out var patch);
            Console.WriteLine($"FreeType version: {major}.{minor}.{patch}");
        }
    }
}