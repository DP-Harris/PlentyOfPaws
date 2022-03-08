using Android;
using Android.App;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

// Allows use of fonts for logo drawing within the app.
[assembly: ExportFont("Font Awesome 6 Free-Regular-400.otf", Alias = "FAR")]
[assembly: ExportFont("Font Awesome 6 Brands-Regular-400.otf", Alias = "FAB")]
[assembly: ExportFont("Font Awesome 6 Free-Solid-900.otf", Alias = "FAS")]

// Required permissions to access and use location of app user.
[assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]
[assembly: UsesFeature("android.hardware.location", Required = false)]
[assembly: UsesFeature("android.hardware.location.gps", Required = false)]
[assembly: UsesFeature("android.hardware.location.network", Required = false)]
[assembly: UsesPermission(Manifest.Permission.AccessBackgroundLocation)]


// Needed for Picking photo/video
[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)]

// Needed for Taking photo/video
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
[assembly: UsesPermission(Android.Manifest.Permission.Camera)]

// Add these properties if you would like to filter out devices that do not have cameras, or set to false to make them optional
[assembly: UsesFeature("android.hardware.camera", Required = true)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = true)]

[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)]