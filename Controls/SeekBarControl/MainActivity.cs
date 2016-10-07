using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SeekBarControl
{
    [Activity(Label = "SeekBarControl", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity,SeekBar.IOnSeekBarChangeListener
    {
        SeekBar _seekBar;
        TextView _textView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            _seekBar = FindViewById<SeekBar>(Resource.Id.seekBar1);
            _textView = FindViewById<TextView>(Resource.Id.textView1);

            _seekBar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
                if (e.FromUser)
                    _textView.Text = string.Format("El valor de el SeekBar es {0}", e.Progress);
            };

        }

        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            if (fromUser)
                _textView.Text = string.Format("ajustaste el valor de seekBar a {0}", seekBar.Progress);
        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
            System.Diagnostics.Debug.WriteLine("Tracking changes");
        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
            System.Diagnostics.Debug.WriteLine("Stopped tracking changes.");
        }
    }
}

