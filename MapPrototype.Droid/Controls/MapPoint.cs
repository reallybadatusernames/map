using System;

using Android.Util;
using Android.Widget;
using Android.Runtime;
using Android.Content;

namespace MapPrototype.Droid.Controls
{
    public class MapPoint : ImageButton 
    {
        private double _xPos;

        private double _yPos;

        private int _width;

        private int _height;

        private double _parentWidth;

        private double _parentHeight;

        private double _lOffset;

        private double _tOffset;

        public MapPoint(Context context) : base(context)
        {
        }

        public MapPoint(IntPtr javaReference, JniHandleOwnership handle) : base(javaReference, handle)
        {
        }

        public MapPoint(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        #region Marker Positions
        public void setPosition(double xPos, double yPos, double lOffset, double tOffset, double parentWidth, double parentHeight, int width, int height)
        {
            _width = width;
            _height = height;
            _xPos = xPos;
            _yPos = yPos;
            _parentHeight = parentHeight;
            _parentWidth = parentWidth;
            _lOffset = lOffset;
            _tOffset = tOffset;

            this.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(_width, _height);

            SetX((float)(((_parentWidth * (_xPos / 100)) + _lOffset) - (_width / 2)));
            SetY((float)(((_parentHeight * (_yPos / 100)) + _tOffset) - (_height / 2)));
        }

        public void setPosition(float xPos, float yPos, float lOffset, float tOffset, float parentWidth, float parentHeight, int width, int height)
        {
            _width = width;
            _height = height;
            _xPos = xPos;
            _yPos = yPos;
            _lOffset = lOffset;
            _tOffset = tOffset;
            _parentHeight = parentHeight;
            _parentWidth = parentWidth;

            this.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(_width, _height);

            SetX((float)(((_parentWidth * (_xPos / 100)) + _lOffset) - (_width / 2)));
            SetY((float)(((_parentHeight * (_yPos / 100)) + _tOffset) - (_height / 2)));
        }

        #endregion

    }
}