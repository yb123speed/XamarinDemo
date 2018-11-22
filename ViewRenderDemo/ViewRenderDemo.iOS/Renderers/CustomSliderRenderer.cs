using System;
using ViewRenderDemo.Controls;
using ViewRenderDemo.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;

[assembly: ExportRenderer(typeof(CustomSlider),typeof(CustomSliderRenderer))]
namespace ViewRenderDemo.iOS.Renderers
{
    public class CustomSliderRenderer : SliderRenderer
    {
        static readonly double THUMB_WIDTH = 52;
        static readonly double THUMB_HEIGHT = 52;
        static readonly float MAXVALUE = 100;
        static readonly float MINVALUE = 0;

        CustomSlider customSlider;
        bool isUnlock = false;

        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
            if(e.NewElement != null)
            {
                customSlider = e.NewElement as CustomSlider;
            }

            if(e.OldElement != null)
            {

            }

            if(Control != null)
            {
                var thumbsize = new CGSize(THUMB_WIDTH, THUMB_HEIGHT);
                Control.SetThumbImage(Resize(UIImage.FromBundle("thumb.png"), thumbsize),UIControlState.Normal);
                Control.SetMinTrackImage(UIImage.FromBundle("sliderMaxMin_02.png"),UIControlState.Normal);
                Control.SetMaxTrackImage(UIImage.FromBundle("sliderMaxMin_02.png"), UIControlState.Normal);

                Control.MaxValue = MAXVALUE;
                Control.MinValue = MINVALUE;
                Control.TouchUpInside += OnTouchUpInside;
                Control.ValueChanged += OnValueChanged;
            }
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            CGRect trackRect = Control.TrackRectForBounds(Control.Bounds);
            CGRect thumbRect = Control.ThumbRectForBounds(Control.Bounds, trackRect, Control.Value);
            var centerThumbX = (int)(thumbRect.X + (THUMB_WIDTH / 2));
            var centerThumbY = (int)(thumbRect.Y + (THUMB_HEIGHT / 2));
            Console.WriteLine("thumb center X:{0} Y:{1}", centerThumbX, centerThumbY);
            if (!isUnlock && Control.Value < Control.MaxValue)
            {
                customSlider.OnValueChanging(centerThumbX, centerThumbY);
            }
            if(!isUnlock && Control.Value>= Control.MaxValue)
            {
                isUnlock = true;
                customSlider.OnUnlock();
            }
        }

        private void OnTouchUpInside(object sender, EventArgs e)
        {
            if (!isUnlock && Control.Value < 100f)
            {
                Control.Value = 0;
                customSlider.OnTouchUp();
            }
        }

        private UIImage Resize(UIImage uIImage, CGSize thumbsize)
        {
            UIGraphics.BeginImageContextWithOptions(thumbsize, false, 0.0f);
            uIImage.Draw(new CGRect(0, 0, thumbsize.Width, thumbsize.Height));

            UIImage newImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return newImage;
        }
    }
}

