using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace DisplayAnImage
{
    [Activity(Label = "DisplayAnImage", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += delegate
            {
                var imageView = FindViewById<ImageView>(Resource.Id.demoImageView);
                imageView.SetImageResource(Resource.Drawable.madagascar2);
            };
        }
    }
           
           
}

