using System;

using Airbnb.Lottie;

using Foundation;

namespace MapPrototype.iOS.Controls
{
    public class MapWidget : LOTAnimationView
    {
        #region Constructors

        public MapWidget() : base() { }

        public MapWidget(NSUrl url) : base(url) { }

        public MapWidget(IntPtr handle) : base(handle) { }

        public MapWidget(NSCoder coder) : base(coder) { }

        public MapWidget(NSObjectFlag t) : base(t) { }

        public MapWidget(LOTComposition? model, NSBundle? bundle) : base(model, bundle) { }


        #endregion

        #region Properties

        private double _xPos;

        private double _yPos;

        private int _width;

        private int _height;

        private double _parentWidth;

        private double _parentHeight;

        private double _lOffset;

        private double _tOffset;

        public string RequestUri { get; set; }

        public string AnimationUrl { get; set; }

        public string AnimationJson { get; set; }


        #endregion

        public void setPosition(double xPos, double yPos, double lOffset, double tOffset, double parentWidth, double parentHeight, double widthPercent, double heightPercent)
        {
            _xPos = xPos;
            _yPos = yPos;
            _parentHeight = parentHeight;
            _parentWidth = parentWidth;
            _width = Convert.ToInt32(_parentWidth * (widthPercent / 100));
            _height = Convert.ToInt32(_parentHeight * (heightPercent / 100));
            _lOffset = lOffset;
            _tOffset = tOffset;

            Frame = new CoreGraphics.CGRect
            (
                (float)((_parentWidth * (_xPos / 100))),
                (float)((_parentHeight * (_yPos / 100))),
                _width,
                _height
            );
        }
    }
}
