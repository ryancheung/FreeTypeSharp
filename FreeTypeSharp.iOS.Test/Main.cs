using UIKit;
using FreeTypeSharp;
using System;
using static FreeTypeSharp.Native.FT;

namespace FreeTypeSharp.iOS.Test {
	public class Application {
		// This is the main entry point of the application.
		static void Main (string [] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");

            var library = new FreeTypeLibrary();
            FT_Library_Version(library.Native, out var major, out var minor, out var patch);
            Console.WriteLine($"FreeType version: {major}.{minor}.{patch}");
		}
	}
}
