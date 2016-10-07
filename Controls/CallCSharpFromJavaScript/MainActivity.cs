using Android.App;
using Android.OS;
using Android.Webkit;

namespace CallCSharpFromJavaScript
{
    [Activity(Label = "CallCSharpFromJavaScript", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        const string html=  @"
            <html>
                <body>
                    <p>Demo calling c# from JavaScript</p>
                    <button type=""button"" onclick=""CSharp.ShowToast()"">Call C#</button>
                </body>
            </html>";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            WebView webView = new WebView(this);

            SetContentView(webView);

            webView.Settings.JavaScriptEnabled = true;
            webView.AddJavascriptInterface(new MyJSInterface(this), "CSharp");
            webView.LoadData(html, "text/html", null);
        }
    }
}

