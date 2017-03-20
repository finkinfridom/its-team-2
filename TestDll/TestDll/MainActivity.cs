using Android.App;
using Android.Widget;
using Android.OS;
using loginCheck;

namespace TestDll
{
    [Activity(Label = "TestDll", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            TextView outLog = FindViewById<TextView>(Resource.Id.textView1);
            outLog.Text = Password.makePassword("miaPassword123");
        }
    }
}

