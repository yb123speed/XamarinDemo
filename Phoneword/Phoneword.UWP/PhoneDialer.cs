using Phoneword.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls;
using Windows.UI.Popups;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]
namespace Phoneword.UWP
{
    public class PhoneDialer : IDialer
    {
        bool dialed = false;
        public bool Dial(string number)
        {
            DialNumber(number);
            return dialed;
        }

        async Task DialNumber(string number)
        {
            var phoneLine = await GetDefaultPhoneLineAsync();
            if (phoneLine != null)
            {
                phoneLine.Dial(number, number);
                dialed = true;
            }
            else
            {
                var dialog = new MessageDialog("找不到拨打电话的线路");
                await dialog.ShowAsync();
                dialed = false;
            }

        }

        async Task<PhoneLine> GetDefaultPhoneLineAsync()
        {
            var phoneCallStore = await PhoneCallManager.RequestStoreAsync();
            var lineId = await phoneCallStore.GetDefaultLineAsync();
            return await PhoneLine.FromIdAsync(lineId);
        }
    }
}
