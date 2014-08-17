using Android.App;
using Android.OS;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


namespace BuildStuff14.Droid
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/buildstuff14")]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            SetPage(App.GetMainPage());
        }
    }
}
