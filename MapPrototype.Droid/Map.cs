using System.Collections.Generic;

using Android.OS;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Content.PM;

using MapPrototype.Droid.Controls;

namespace MapPrototype.Droid
{
    [Activity(Label = "Map", LaunchMode = LaunchMode.SingleTask, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Map : Activity
    {
        /// <summary>
        /// Represents the data that will come from the server
        /// </summary>
        public List<WayPoint> Points 
        { 
            get
            {
                switch (NumMarkers)
                {
                    default:
                        return new List<WayPoint>
                        {
                            new WayPoint { Id = 3, Title = "Three", XPos = 49.97981317, YPos = 1.825529196, Color = Color.Black },
                            new WayPoint { Id = 2,  Title = "Two", XPos = 51.23278898, YPos = 48.29354509, Color = Color.Black },
                            new WayPoint { Id = 1,  Title = "One", XPos = 35.77942057, YPos = 97.91474779, Color = Color.Black },

                        };
                    case 4:
                        return new List<WayPoint>
                        {
                            new WayPoint { Id = 1, Title = "One", XPos = 35.77942, YPos = 97.9147, Color = Color.Black },
                            new WayPoint { Id = 2, Title = "Two", XPos = 91.46723, YPos = 59.3296, Color = Color.Black },
                            new WayPoint { Id = 3, Title = "Three", XPos = 11.27678, YPos = 35.6807, Color = Color.Black },
                            new WayPoint { Id = 4, Title = "Four", XPos = 49.9798, YPos = 1.8255, Color = Color.Black },
                        };
                    case 5:
                        return new List<WayPoint>
                        {
                            new WayPoint { Id = 1, Title = "One", XPos = 35.779, YPos = 97.914, Color = Color.Black },
                            new WayPoint { Id = 2, Title = "Two", XPos = 81.86108, YPos = 73.8509, Color = Color.Black },
                            new WayPoint { Id = 3, Title = "Three", XPos = 50.8151, YPos = 48.2935, Color = Color.Black },
                            new WayPoint { Id = 4, Title = "Four", XPos = 6.6825, YPos = 28.0467, Color = Color.Black },
                            new WayPoint { Id = 5, Title = "Five", XPos = 49.9798, YPos = 1.82552, Color = Color.Black },
                        };
                    case 7:
                        return new List<WayPoint>
                        {
                            new WayPoint { Id = 1, Title = "One", XPos = 35.77942057, YPos = 97.91474779, Color = Color.Black },
                            new WayPoint { Id = 2, Title = "Two", XPos = 68.913, YPos = 78.580, Color = Color.Black },
                            new WayPoint { Id = 3, Title = "Three", XPos = 93.833, YPos = 62.4828, Color = Color.Black },
                            new WayPoint { Id = 4, Title = "Four", XPos = 66.1292, YPos = 50.450, Color = Color.Black },
                            new WayPoint { Id = 5, Title = "Four", XPos = 22.692, YPos = 42.402, Color = Color.Black },
                            new WayPoint { Id = 6, Title = "Four", XPos = 9.884, YPos = 19.416, Color = Color.Black },
                            new WayPoint { Id = 7, Title = "Three", XPos = 49.97981317, YPos = 1.825529196, Color = Color.Black },
                        };
                    case 10:
                        return new List<WayPoint>
                        {
                            new WayPoint { Id = 1, Title = "One", XPos = 35.77942, YPos = 97.91474779, Color = Color.Black },
                            new WayPoint { Id = 2, Title = "Two", XPos = 54.57405783, YPos = 83.64242862, Color = Color.Black },
                            new WayPoint { Id = 3, Title = "Three", XPos = 80.74733047, YPos = 74.59776124, Color = Color.Black },
                            new WayPoint { Id = 4, Title = "Four", XPos = 92.16333236, YPos = 59.91054907, Color = Color.Black },
                            new WayPoint { Id = 5, Title = "Four", XPos = 66.40771833, YPos = 50.45098869, Color = Color.Black },
                            new WayPoint { Id = 6, Title = "Four", XPos = 36.89317685, YPos = 46.136101, Color = Color.Black },
                            new WayPoint { Id = 7, Title = "Four", XPos = 12.25131911, YPos = 36.51058392, Color = Color.Black },
                            new WayPoint { Id = 8, Title = "Four", XPos = 9.884587005, YPos = 19.66592816, Color = Color.Black },
                            new WayPoint { Id = 9, Title = "Four", XPos = 31.60283451, YPos = 8.214881382, Color = Color.Black },
                            new WayPoint { Id = 10, Title = "Three", XPos = 49.97981317, YPos = 1.161700397, Color = Color.Black },
                        };
                }
            } 
        }

        /// <summary>
        /// The actual controls that represent the Way Point
        /// </summary>
        public List<MapPoint> MapPoints { get; set; }

        /// <summary>
        /// Represents the data that will come from the server
        /// </summary>
        public List<Widget> Widgets 
        { 
            get
            {
                return new List<Widget>
                {
                    new Widget { X = 32.28, Y = 18.62, WidthPercent = 36.74, HeightPercent = 14.91, Url = "client/maps/40180-dancing-burger.json"},
                    new Widget { X = 12, Y = 48.88, WidthPercent = 20, HeightPercent = 10, Url = "client/maps/40180-dancing-burger.json"},
                    new Widget { X = 4.39, Y = 60, WidthPercent = 20.09, HeightPercent = 14.91, Url = "client/maps/40180-dancing-burger.json"},
                    new Widget { X = 61.34, Y = 70.67, WidthPercent = 36.74, HeightPercent = 14.91, Url = "client/maps/40180-dancing-burger.json"}
                };
            }
        }

        /// <summary>
        /// The acutal controls that represents the Widgets
        /// </summary>
        public List<MapWidget> MapWidgets { get; set; }

        private bool loaded;

        private int NumMarkers { get; set; }

        private RelativeLayout markers;

        private RelativeLayout widgets;

        private ImageView map;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestWindowFeature(WindowFeatures.NoTitle);
            Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

            SetContentView(Resource.Layout.layout_map);
        }
       
        public override void OnWindowFocusChanged(bool hasFocus)
        {
            base.OnWindowFocusChanged(hasFocus);

            if (loaded)
                return;


            var dimension = getImageDimensions();

            var tOffset = (map.Height - dimension.Y) / 2;
            var lOffset = (map.Width - dimension.X) / 2;
            var dimen = dpToPx(50);

            if (MapPoints == null)
                MapPoints = new List<MapPoint>();


            ////add points
            //foreach (var point in Points)
            //{
             
            //    var mapPoint = new MapPoint(this);
            //    mapPoint.SetImageBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.waypoint));
            //    mapPoint.SetBackgroundColor(Color.Transparent);
            //    mapPoint.SetScaleType(ImageView.ScaleType.FitCenter);
            //    mapPoint.setPosition(point.XPos, point.YPos, lOffset, tOffset, dimension.X, dimension.Y, dimen, dimen);
            //    mapPoint.Tag = point.Id;
            //    markers.AddView(mapPoint);
            //    mapPoint.Click += MapPoint_Click;

            //    MapPoints.Add(mapPoint);
            //}

            foreach (var widget in Widgets)
            {
                var mapWidget = new MapWidget(this);
                mapWidget.SetPosition(widget.X, widget.Y, lOffset, tOffset, dimension.X, dimension.Y, widget.WidthPercent, widget.HeightPercent);
                mapWidget.RequestUri = "https://www.lottery.ok.gov/";
                mapWidget.AnimationUrl = "client/maps/40180-dancing-burger.json";
                widgets.AddView(mapWidget);
                mapWidget.LoadAnimation();
            }

            loaded = true;
        }

        private void MapPoint_Click(object sender, System.EventArgs e)
        {
            var id = System.Convert.ToInt32(((ImageButton)sender).Tag);
            var mapPoint = (MapPoint)sender;

            if (mapPoint != null)
            {
                mapPoint.SetImageBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.waypoint_complete));
                Toast.MakeText(this, "You clicked item " + id, ToastLength.Short).Show();
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            getExtras();
            map = FindViewById<ImageView>(Resource.Id.map);
            markers = FindViewById<RelativeLayout>(Resource.Id.markers);
            widgets = FindViewById<RelativeLayout>(Resource.Id.widgets);

            widgets?.RemoveAllViews();
            markers?.RemoveAllViews();
        }

        public int dpToPx(int dp)
        {
            return System.Convert.ToInt32(dp * Resources.DisplayMetrics.Density);
        }

        private Point getImageDimensions()
        {
            int actualHeight, actualWidth;

            int imageViewHeight = map.Height, imageViewWidth = map.Width;

            int bitmapHeight = map.Drawable.IntrinsicHeight; int bitmapWidth = map.Drawable.IntrinsicWidth;

            if (imageViewHeight * bitmapWidth <= imageViewWidth * bitmapHeight)
            {
                actualWidth = bitmapWidth * imageViewHeight / bitmapHeight;
                actualHeight = imageViewWidth;
            }
            else
            {
                actualHeight = bitmapHeight * imageViewWidth / bitmapWidth;
                actualWidth = imageViewWidth;
            }

            return new Point(actualWidth, actualHeight);    
        }

        private void getExtras()
        {
            NumMarkers = Intent.GetIntExtra("NumMarkers", 3);
        }
    }
}