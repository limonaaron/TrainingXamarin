using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Webkit;

namespace LoadWebPageControl
{
    [Activity(Label = "Administración Crédito-Débito", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            WebView localWebView = FindViewById<WebView>(Resource.Id.LocalWebview);
            localWebView.SetWebViewClient(new WebViewClient());
            localWebView.Settings.JavaScriptEnabled = true;
            localWebView.LoadUrl("https://sso.puntoclave.mx/");

            localWebView.Settings.BuiltInZoomControls = true;
            localWebView.Settings.SetSupportZoom(true);

            localWebView.ScrollBarStyle = ScrollbarStyles.OutsideOverlay;
            localWebView.ScrollbarFadingEnabled = false;
        }
    }
}

