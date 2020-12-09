using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace MapPrototype.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnResume()
        {
            base.OnResume();

            var threeWay = FindViewById<Button>(Resource.Id.threeWay);
            if (threeWay != null)
                threeWay.Click += ThreeWay_Click;

            FindViewById<Button>(Resource.Id.fourWay).Click += FourWay_Click;

            FindViewById<Button>(Resource.Id.fiveWay).Click += FiveWay_Click;

            FindViewById<Button>(Resource.Id.sevenWay).Click += SevenWay_Click;

            FindViewById<Button>(Resource.Id.tenWay).Click += TenWay_Click;

            FindViewById<Button>(Resource.Id.widgetTest).Click += WidgetTest_Click;
        }

        private void WidgetTest_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(WidgetTest));
            StartActivity(intent);
        }

        private void TenWay_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(Map));
            intent.PutExtra("NumMarkers", 10);
            StartActivity(intent);
        }

        private void SevenWay_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(Map));
            intent.PutExtra("NumMarkers", 7);
            StartActivity(intent);
        }

        private void FiveWay_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(Map));
            intent.PutExtra("NumMarkers", 5);
            StartActivity(intent);
        }

        private void FourWay_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(Map));
            intent.PutExtra("NumMarkers", 4);
            StartActivity(intent);
        }

        private void ThreeWay_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(Map));
            intent.PutExtra("NumMarkers", 3);
            StartActivity(intent);
        }
    }
}