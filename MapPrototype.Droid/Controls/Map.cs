using System;

using Android.Util;
using Android.Media;
using Android.Widget;
using Android.Content;
using Android.Runtime;

namespace MapPrototype.Droid.Controls
{
    public class Map : ImageView
    {
        private Image mapImage;

        public Map(Context context) : base(context)
        {
        }

        public Map(IntPtr javaReference, JniHandleOwnership handle) : base(javaReference, handle)
        {
        }

        public Map(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }        
    }
}