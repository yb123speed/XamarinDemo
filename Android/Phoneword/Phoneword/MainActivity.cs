using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Content;

namespace Phoneword
{
    [Activity(Label = "Phone Word", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        static readonly List<string> phoneNumbers = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView translatedPhoneword = FindViewById<TextView>(Resource.Id.TranslatedPhoneWord);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);

            Button translationHistoryButton = FindViewById<Button>(Resource.Id.TranslationHistoryButton);

            string translatedNumber = string.Empty;

            translateButton.Click += (sender, e) =>
             {
                translatedNumber = PhoneTranslator.ToNumber(phoneNumberText.Text);
                if(!string.IsNullOrWhiteSpace(translatedNumber))
                {
                     translatedPhoneword.Text = translatedNumber;
                     phoneNumbers.Add(translatedNumber);
                     translationHistoryButton.Enabled = true;
                     
                }
                else
                {
                     translatedPhoneword.Text = string.Empty;
                }
             };

            translationHistoryButton.Click += (sender, e)=>
            {
                var intent = new Intent(this, typeof(TranslationHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);

            };

        }
    }
}

