﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        string translatedNumber;
        public MainPage()
        {
            InitializeComponent();
        }

        void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = PhoneTranslator.ToNumber(phoneNumberText.Text);
            if(!string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = $"Call {translatedNumber}";
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            if(await this.DisplayAlert(
                "拨号",
                $"是否拨打{translatedNumber}?",
                "是",
                "否"
            )){
                var dialer = DependencyService.Get<IDialer>();
                if(dialer!=null)
                {
                    dialer.Dial(translatedNumber);
                }
            }
        }

        async void OnCallHistory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CallHistoryPage());
        }
    }
}
