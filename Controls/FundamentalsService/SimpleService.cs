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
using System.Threading;
using Android.Util;

namespace FundamentalsService
{
    [Service]
    public class SimpleService : Android.App.Service
    {
        static readonly string TAG = "X:" + typeof(SimpleService).Name;
        static readonly int TimeWait = 4000;
        Timer _timer;

        
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            Log.Debug(TAG, "OnStartCommand called at {2}, flags={0}, startid={1}", flags, startId, DateTime.UtcNow);
            _timer = new Timer(o => { Log.Debug(TAG, "Hellow from SimpleService. {0}", DateTime.UtcNow); },null,0,TimeWait);
            return StartCommandResult.NotSticky;
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            _timer.Dispose();
            _timer = null;
            Log.Debug(TAG, "SimpleService destroyed at {0}", DateTime.UtcNow);
        }
    }
}