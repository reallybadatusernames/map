using System;

using UIKit;
using Foundation;
using CoreGraphics;

namespace MapPrototype.iOS.Controls
{
    public class MapPoint : UIButton
    {
        #region Constructors

        public MapPoint() : base() { }

        public MapPoint(CGRect frame) : base(frame) { }

        public MapPoint(IntPtr handle) : base(handle) { }

        public MapPoint(NSCoder coder) : base(coder) { }

        public MapPoint(NSObjectFlag t) : base(t) { }

        public MapPoint(UIButtonType type) : base(type) { }

        public MapPoint(CGRect frame, UIAction? action) : base(frame, action) { }

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

        #endregion

        public void setPosition(float xPos, float yPos, float lOffset, float tOffset, float parentWidth, float parentHeight, int width, int height)
        {
            _xPos = xPos;
            _yPos = yPos;
            _lOffset = lOffset;
            _tOffset = tOffset;
            _parentWidth = parentWidth;
            _parentHeight = parentHeight;
            _width = width;
            _height = height;

            this.Frame = new CGRect
            (
                (float)(((_parentWidth * (_xPos / 100))) - (_width / 2)),
                (float)(((_parentHeight * (_yPos / 100))) - (_height / 2)),
                _width,
                _height
            );
        }

        public void setPosition(double xPos, double yPos, double lOffset, double tOffset, double parentWidth, double parentHeight, int width, int height)
        {
            _xPos = xPos;
            _yPos = yPos;
            _lOffset = lOffset;
            _tOffset = tOffset;
            _parentWidth = parentWidth;
            _parentHeight = parentHeight;
            _width = width;
            _height = height;

            this.Frame = new CGRect
            (
                (float)(((_parentWidth * (_xPos / 100))) - (_width / 2)),
                (float)(((_parentHeight * (_yPos / 100))) - (_height / 2)),
                _width,
                _height
            );
        }
    }
}
