using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DIYTabPage
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.Children.Add(new DemoPage1());
            this.Children.Add(new DemoPage2());
            this.Children.Add(new DemoPage3());
        }
    }
}
