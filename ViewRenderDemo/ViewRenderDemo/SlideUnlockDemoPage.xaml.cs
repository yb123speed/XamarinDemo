using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace ViewRenderDemo
{
    public partial class SlideUnlockDemoPage : ContentPage
    {
        void Handle_Unlock(object sender, System.EventArgs e)
        {
            Debug.WriteLine("======> Unlock !!!");

        }

        public SlideUnlockDemoPage()
        {
            InitializeComponent();
        }
    }
}
