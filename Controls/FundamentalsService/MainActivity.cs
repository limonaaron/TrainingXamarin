using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FundamentalsService
{
    [Activity(Label = "FundamentalsService", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Button start = FindViewById<Button>(Resource.Id.StartService);
            start.Click += (sender, args) => 
            {
                StartService(new Intent(this, typeof(SimpleService)));
            };

            Button stop = FindViewById<Button>(Resource.Id.stopService);
            stop.Click += (sender, args) =>
            {
                StopService(new Intent(this, typeof(SimpleService)));
            };          
        }

        protected override void OnStop()
        {
            base.OnStop();
            StopService(new Intent(this, typeof(SimpleService)));
        }
    }
}

