using Android.Content;
using Android.Webkit;
using Android.Widget;
using Java.Interop;

namespace CallCSharpFromJavaScript
{
    public class MyJSInterface : Java.Lang.Object
    {
        Context _context;

        public MyJSInterface(Context context)
        {
            _context = context;
        }

        [Export]
        [JavascriptInterface]
        public void ShowToast()
        {
            Toast.MakeText(_context, "Helloe from c#", ToastLength.Short).Show();
        }
    }
}