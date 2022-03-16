using Android.Content.Res;
using PlentyOfPaws.Droid;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ResolutionGroupName("PlainEntryGroup")]
[assembly: ExportEffect(typeof(AndroidPlainEntryEffect), "PlainEntryEffect")]

namespace PlentyOfPaws.Droid
{
    public class AndroidPlainEntryEffect : PlatformEffect
    {
        public AndroidPlainEntryEffect()
        {
        }
        protected override void OnAttached()
        {
            try
            {
                if (Control != null)
                {
                    // Changed from color.white;
                    Android.Graphics.Color entryLineColor = Android.Graphics.Color.Argb(0,0,0,0);
                    Control.BackgroundTintList = ColorStateList.ValueOf(entryLineColor);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error... Unable to set property on attached control", ex.Message);
            }
        }
        protected override void OnDetached()
        {
        }
        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
        }
    }
}
