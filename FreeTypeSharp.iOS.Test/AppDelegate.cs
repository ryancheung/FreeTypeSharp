using Foundation;
using UIKit;
using static FreeTypeSharp.Native.FT;

namespace FreeTypeSharp.iOS.Test {
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate {
		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// create a new window instance based on the screen size
			Window = new UIWindow (UIScreen.MainScreen.Bounds);

			var library = new FreeTypeLibrary();
			FT_Library_Version(library.Native, out var major, out var minor, out var patch);

			// create a UIViewController with a single UILabel
			var vc = new UIViewController ();
			vc.View.AddSubview (new UILabel (Window.Frame) {
				BackgroundColor = UIColor.White,
				TextAlignment = UITextAlignment.Center,
				Text = "Hello, iOS!" + $" FreeType version: {major}.{minor}.{patch}"
			});
			Window.RootViewController = vc;

			// make the window visible
			Window.MakeKeyAndVisible ();

			return true;
		}
	}
}
