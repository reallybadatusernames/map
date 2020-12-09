using System;
using System.Net.Http;
using System.Threading.Tasks;

using Android.Util;
using Android.Content;
using Android.Runtime;

using Com.Airbnb.Lottie;

namespace MapPrototype.Droid.Controls
{
    public class MapWidget : LottieAnimationView
    {
        #region Properties/Constructors

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

        public MapWidget(Context context) : base(context)
        {
        }

        public MapWidget(IntPtr javaReference, JniHandleOwnership handle) : base(javaReference, handle)
        {
        }

        public MapWidget(Context context, IAttributeSet attrs) : base(context, attrs)
        {

        }

        #endregion

        #region Control Positioning

        public void SetPosition(double xPos, double yPos, double lOffset, double tOffset, double parentWidth, double parentHeight, double widthPercent, double heightPercent)
        {
            _xPos = xPos;
            _yPos = yPos;
            _parentHeight = parentHeight;
            _parentWidth = parentWidth;
            _width = Convert.ToInt32(_parentWidth * (widthPercent / 100));
            _height = Convert.ToInt32(_parentHeight * (heightPercent / 100));
            _lOffset = lOffset;
            _tOffset = tOffset;

            this.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(_width, _height);

            SetX((float)((_parentWidth * (_xPos / 100)) + _lOffset));
            SetY((float)((_parentHeight * (_yPos / 100)) + _tOffset));
        }

        #endregion

        #region Overrides

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);
        }

        #endregion

        #region Animations

        public async Task LoadAnimationAsync()
        {
            if (string.IsNullOrEmpty(AnimationUrl) || string.IsNullOrEmpty(RequestUri))
                return;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(RequestUri);
                var response = await client.GetAsync(AnimationUrl);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    LottieComposition.Factory.FromJsonString(data, (composition) =>
                    {
                        AnimationJson = data;
                        SetComposition(composition);
                    });
                }
            }
        }


        public void LoadAnimation()
        {
            if (string.IsNullOrEmpty(AnimationUrl) || string.IsNullOrEmpty(RequestUri))
                return;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(RequestUri);
                var response = client.GetAsync(AnimationUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    LottieComposition.Factory.FromJsonString(data, (composition) =>
                    {
                        AnimationJson = data;
                        SetComposition(composition);
                    });
                }
            }
        }

        public void SetComposition(LottieComposition composition)
        {
            Composition = composition;
            Loop(true);
            PlayAnimation();
        }

        #endregion

    }
}