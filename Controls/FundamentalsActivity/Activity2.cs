using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FundamentalsActivity
{
    [Activity(Label = "Activity2")]
    public class Activity2 : Android.App.Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string text = Intent.GetStringExtra("MyData") ?? "Data not available";
            
        }
    }
}