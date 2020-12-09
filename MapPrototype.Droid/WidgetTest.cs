using System;
using System.Net.Http;

using Android.App;
using Android.OS;

using MapPrototype.Droid.Controls;

namespace MapPrototype.Droid
{
    [Activity(Label = "WidgetTest")]
    public class WidgetTest : Activity
    {
        MapWidget widget;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout_widget_test);
        }

        protected override void OnResume()
        {
            base.OnResume();

            widget = FindViewById<MapWidget>(Resource.Id.animation_view);

            widget.RequestUri = "https://www.lottery.ok.gov";
            widget.AnimationUrl = "client/maps/40180-dancing-burger.json";
            widget.LoadAnimation();
        }
    }
}