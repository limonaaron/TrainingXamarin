using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Webkit;

namespace LoadLocalContent
{
    [Activity(Label = "LoadLocalContent", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            WebView localWebView = FindViewById<WebView>(Resource.Id.LocalWebView);
            localWebView.LoadUrl("file:///android_asset/Content/Home.html");
        }
    }
}

