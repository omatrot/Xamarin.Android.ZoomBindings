using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using US.Zoom.Sdk;

namespace ZoomDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IZoomSDKInitializeListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            ZoomSDKInitParams initParams = new ZoomSDKInitParams();
            initParams.AppKey = "x6yCTnMP3nWljshoJ6wPCagfTIbnF34AO0cc";
            initParams.AppSecret = "u85nEugHkzG0RtXnPEfijtd7L3XnQZorVU2K";
            initParams.Domain = "zoom.us";
            initParams.VideoRawDataMemoryMode = ZoomSDKRawDataMemoryMode.ZoomSDKRawDataMemoryModeStack;

            ZoomSDK.Instance.Initialize(this, this, initParams);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnZoomAuthIdentityExpired()
        {
            throw new System.NotImplementedException();
        }

        public void OnZoomSDKInitializeResult(int p0, int p1)
        {
            throw new System.NotImplementedException();
        }
    }
}