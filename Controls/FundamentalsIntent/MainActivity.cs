using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FundamentalsIntent
{
    [Activity(Label = "FundamentalsIntent", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        string option = "Launch the Map Application";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
            {
                option = "Open a WebPage in the Browser Application";
                if (option.Equals("Launch the Map Application"))
                {
                    var geoUri = Android.Net.Uri.Parse("geo:19.045256, -98.147875");
                    var mapIntent = new Intent(Intent.ActionView, geoUri);
                    StartActivity(mapIntent);
                }
                else if (option.Equals("Launh the Phone Dialer"))
                {
                    var uri = Android.Net.Uri.Parse("tel:2225019936");
                    var intent = new Intent(Intent.ActionDial, uri);
                    StartActivity(intent);
                }
                else if (option.Equals("Open a WebPage in the Browser Application"))
                {
                    var uri = Android.Net.Uri.Parse("https://sso.puntoclave.mx");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }                
            };
        }
    }
}

