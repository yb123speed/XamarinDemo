using System;

using Xamarin.Forms;

namespace ViewRenderDemo.Controls
{
    public class CornerRaidusContentView : ContentView
    {
        public static readonly BindableProperty CornerRaidusProperty = BindableProperty.Create(
            "CornerRaidus",
            typeof(double),
            typeof(CornerRaidusContentView),
            0.0D
        );

        /// <summary>
        /// 圆角弧度
        /// </summary>
        /// <value>The corner raidus.</value>
        public double CornerRaidus
        {
            get { return (double)GetValue(CornerRaidusProperty); }
            set { SetValue(CornerRaidusProperty, value); }
        }
    }
}

