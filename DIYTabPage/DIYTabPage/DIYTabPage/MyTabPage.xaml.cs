using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DIYTabPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyTabPage : ContentPage
	{
		public MyTabPage ()
		{
			InitializeComponent ();
		}

        private void Demo1_Tapped(object sender, EventArgs e)
        {
            var page = new DemoPage1();
            cvContentPlaceHolder.Content = page.Content;
        }

        private void Demo2_Tapped(object sender, EventArgs e)
        {
            var page = new DemoPage2();
            cvContentPlaceHolder.Content = page.Content;
        }

        private void Demo3_Tapped(object sender, EventArgs e)
        {
            var page = new DemoPage3();
            cvContentPlaceHolder.Content = page.Content;
        }
    }
}