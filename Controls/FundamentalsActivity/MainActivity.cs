using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FundamentalsActivity
{
    [Activity(Label = "FundamentalsActivity", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        string option = "Pass Data Betwen Activity";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += delegate
            {
                if (option.Equals("Pass Data Betwen Activity"))
                {
                    var activity2 = new Intent(this, typeof(Activity2));
                    activity2.PutExtra("MyData", "Data From Activity1");
                    StartActivity(activity2);
                }
                else
                {
                    StartActivity(typeof(Activity2));
                }
            };
        }
    }
}

