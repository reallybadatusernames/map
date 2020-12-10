using System;
using System.Collections.Generic;

using UIKit;
using Foundation;

using MapPrototype.iOS.Controls;

using Airbnb.Lottie;
using System.Drawing;

namespace MapPrototype.iOS
{
	public partial class MapView : UIViewController
	{
        public MapView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            map.Frame = new CoreGraphics.CGRect(0, 0, container.Frame.Width, container.Frame.Height);
            var dimen = getImageDimensions();

            var tOffset = (container.Frame.Height - dimen.Y) / 2;
            var lOffset = (container.Frame.Width - dimen.X) / 2;


            lOffset = (lOffset < 0) ? 0 : lOffset;
            tOffset = (tOffset < 0) ? 0 : tOffset;

            ////add points
            foreach (var point in Points)
            {

                var mapPoint = new MapPoint();
                mapPoint.SetBackgroundImage(UIImage.FromFile("waypoint.png"), UIControlState.Normal);
                mapPoint.setPosition(point.XPos, point.YPos, lOffset, tOffset, container.Frame.Width, container.Frame.Height, 50, 50);
                container.Add(mapPoint);
                container.BringSubviewToFront(mapPoint);

                //mapPoint.SetImageBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.waypoint));
                //mapPoint.SetBackgroundColor(Color.Transparent);
                //mapPoint.SetScaleType(ImageView.ScaleType.FitCenter);
                //mapPoint.setPosition(point.XPos, point.YPos, lOffset, tOffset, dimension.X, dimension.Y, dimen, dimen);
                //mapPoint.Tag = point.Id;
                //markers.AddView(mapPoint);
                //mapPoint.Click += MapPoint_Click;

                //MapPoints.Add(mapPoint);
            }


            foreach (var widget in Widgets)
            {
                var ctl = new MapWidget(new NSUrl("https://wwww.lottery.ok.gov/" + widget.Url));
                ctl.setPosition(widget.X, widget.Y, lOffset, tOffset, container.Frame.Width, container.Frame.Height, widget.WidthPercent, widget.HeightPercent);
                container.Add(ctl);
            }
        }

        private int NumMarkers = 3;

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
                            new WayPoint { Id = 3, Title = "Three", XPos = 38.79941, YPos = 90.27475 },
                            new WayPoint { Id = 2,  Title = "Two", XPos = 51.97657, YPos = 46.22765 },
                            new WayPoint { Id = 1,  Title = "One", XPos = 50.43924, YPos = 5.27693},
                                                        new WayPoint { Id = 4, Title = "Four", XPos = 66.81698, YPos = 72.69952}
                        };
                    case 4:
                        return new List<WayPoint>
                        {
                            new WayPoint { Id = 1, Title = "One", XPos = 35, YPos = 97.9147 },
                            new WayPoint { Id = 2, Title = "Two", XPos = 91.46723, YPos = 59.3296},
                            new WayPoint { Id = 3, Title = "Three", XPos = 11.27678, YPos = 35.6807 },
                            new WayPoint { Id = 4, Title = "Four", XPos = 49.9798, YPos = 1.8255 },
                        };
                    case 5:
                        return new List<WayPoint>
                        {
                            new WayPoint { Id = 1, Title = "One", XPos = 35.779, YPos = 97.914 },
                            new WayPoint { Id = 2, Title = "Two", XPos = 81.86108, YPos = 73.8509 },
                            new WayPoint { Id = 3, Title = "Three", XPos = 50.8151, YPos = 48.2935},
                            new WayPoint { Id = 4, Title = "Four", XPos = 6.6825, YPos = 28.0467},
                            new WayPoint { Id = 5, Title = "Five", XPos = 49.9798, YPos = 1.82552 },
                        };
                    case 7:
                        return new List<WayPoint>
                        {
                            new WayPoint { Id = 1, Title = "One", XPos = 35.77942057, YPos = 97.91474779 },
                            new WayPoint { Id = 2, Title = "Two", XPos = 68.913, YPos = 78.580},
                            new WayPoint { Id = 3, Title = "Three", XPos = 93.833, YPos = 62.4828},
                            new WayPoint { Id = 4, Title = "Four", XPos = 66.1292, YPos = 50.450 },
                            new WayPoint { Id = 5, Title = "Four", XPos = 22.692, YPos = 42.402},
                            new WayPoint { Id = 6, Title = "Four", XPos = 9.884, YPos = 19.416 },
                            new WayPoint { Id = 7, Title = "Three", XPos = 49.97981317, YPos = 1.825529196 },
                        };
                    case 10:
                        return new List<WayPoint>
                        {
                            new WayPoint { Id = 1, Title = "One", XPos = 35.77942, YPos = 97.91474779 },
                            new WayPoint { Id = 2, Title = "Two", XPos = 54.57405783, YPos = 83.64242862 },
                            new WayPoint { Id = 3, Title = "Three", XPos = 80.74733047, YPos = 74.59776124},
                            new WayPoint { Id = 4, Title = "Four", XPos = 92.16333236, YPos = 59.91054907 },
                            new WayPoint { Id = 5, Title = "Four", XPos = 66.40771833, YPos = 50.45098869},
                            new WayPoint { Id = 6, Title = "Four", XPos = 36.89317685, YPos = 46.136101 },
                            new WayPoint { Id = 7, Title = "Four", XPos = 12.25131911, YPos = 36.51058392 },
                            new WayPoint { Id = 8, Title = "Four", XPos = 9.884587005, YPos = 19.66592816 },
                            new WayPoint { Id = 9, Title = "Four", XPos = 31.60283451, YPos = 8.214881382 },
                            new WayPoint { Id = 10, Title = "Three", XPos = 49.97981317, YPos = 1.161700397},
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
                    new Widget { X = 61.34, Y = 75.67, WidthPercent = 36.74, HeightPercent = 14.91, Url = "client/maps/40180-dancing-burger.json"}
                };
            }
        }

        /// <summary>
        /// The acutal controls that represents the Widgets
        /// </summary>
        public List<MapWidget> MapWidgets { get; set; }


        private Point getImageDimensions()
        {
            nfloat actualHeight, actualWidth;


            nfloat imageViewHeight = map.Frame.Height;
            nfloat imageViewWidth = map.Frame.Width;

            nfloat bitmapHeight = map.IntrinsicContentSize.Height;
            nfloat bitmapWidth = map.IntrinsicContentSize.Width;

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

            return new Point(Convert.ToInt32(actualWidth), Convert.ToInt32(actualHeight));
        }

    }
}
