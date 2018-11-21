using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using ViewRenderDemo.Controls;
using ViewRenderDemo.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CornerRaidusContentView), typeof(CornerRaidusContentViewRenderer))]
namespace ViewRenderDemo.Droid.Renderers
{
    public class CornerRaidusContentViewRenderer : ViewRenderer
    {
        private float _cornerRaidus;
        private RectF _bounds = new RectF();
        private Path _path = new Path();

        public CornerRaidusContentViewRenderer(Context context):base(context){}

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var cornerRaidusContentView = e.NewElement as CornerRaidusContentView;

                _cornerRaidus = TypedValue.ApplyDimension(
                    ComplexUnitType.Dip,
                    (float)cornerRaidusContentView.CornerRaidus,
                    Context.Resources.DisplayMetrics
                );
            }

            if (e.OldElement != null)
            {

            }

            if (Control != null)
            {

            }
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);

            //用自己的宽高定义画图的路径Path
            _bounds = new RectF(0,0,w,h);
            _path = new Path();
            _path.Reset();
            _path.AddRoundRect(_bounds, _cornerRaidus, _cornerRaidus,Path.Direction.Cw);
            _path.Close();
        }

        public override void Draw(Canvas canvas)
        {
            canvas.Save();
            canvas.ClipPath(_path);
            base.Draw(canvas); //画出路径
            canvas.Restore();
        }
    }
}
